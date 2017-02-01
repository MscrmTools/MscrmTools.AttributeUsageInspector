using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;

namespace MscrmTools.AttributeUsageInspector
{
    class DetectiveEngine
    {
        private readonly IOrganizationService service;

        const string FetchXml = "<fetch mapping=\"logical\" aggregate=\"true\" count=\"5000\"><entity name=\"{0}\">{1}<filter>{2}</filter></entity></fetch>";


        public DetectiveEngine(IOrganizationService service)
        {
            this.service = service;
        }

        public DetectionResults GetUsage(EntityMetadata emd, bool useStdQueries, Settings settings, BackgroundWorker worker = null)
        {
            var result = new DetectionResults();

            List<AttributeMetadata> attributes = new List<AttributeMetadata>();

            if (useStdQueries)
            {
                var query = new QueryExpression(emd.LogicalName)
                {
                    PageInfo = new PagingInfo
                    {
                        Count = settings.RecordsReturnedPerTrip,
                        PageNumber = 1
                    },
                    ColumnSet = new ColumnSet(true),
                    NoLock = true
                };

                EntityCollection ec;
                Dictionary<AttributeMetadata, int> attributesCount = new Dictionary<AttributeMetadata, int>();
                int total = 0;
                do
                {
                    ec = service.RetrieveMultiple(query);
                    total += ec.Entities.Count;
                    query.PageInfo.PageNumber++;
                    query.PageInfo.PagingCookie = ec.PagingCookie;

                    worker?.ReportProgress(0, string.Format("{0} records retrieved...", total));

                    foreach (var record in ec.Entities)
                    {
                        foreach (var attribute in emd.Attributes.Where(a =>
                            a.AttributeOf == null
                            && a.AttributeType.Value != AttributeTypeCode.Virtual
                            && a.AttributeType.Value != AttributeTypeCode.PartyList
                            && a.IsValidForRead.Value
                            && a.LogicalName.IndexOf("composite") < 0
                            ).OrderBy(a => a.LogicalName))
                        {
                            if (!record.Contains(attribute.LogicalName)) continue;

                            if (!attributesCount.ContainsKey(attribute))
                            {
                                attributesCount.Add(attribute, 0);
                            }
                            attributesCount[attribute] = attributesCount[attribute] + 1;
                        }
                    }
                } while (ec.MoreRecords);

                result.Total = total;
                result.Entity = emd.LogicalName;

                foreach (var key in attributesCount.Keys)
                {
                    result.Results.Add(new DetectionResult
                    {
                        Attribute = key,
                        NotNull = attributesCount[key],
                        Percentage = result.Total != 0 ? (double)(attributesCount[key] * 100) / (double)result.Total : 0
                    });
                }
            }
            else
            {
                var emRequest = new ExecuteMultipleRequest
                {
                    Settings = new ExecuteMultipleSettings
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    },
                    Requests = new OrganizationRequestCollection()
                };

                var fetchXmlAttrPart = string.Format("<attribute name=\"{0}\" aggregate=\"count\" alias=\"count\"/>",
                    emd.PrimaryIdAttribute);
                emRequest.Requests.Add(new RetrieveMultipleRequest
                {
                    Query = new FetchExpression(string.Format(FetchXml, emd.LogicalName, fetchXmlAttrPart, ""))
                });

                foreach (var attribute in emd.Attributes.Where(a =>
                    a.AttributeOf == null
                    && a.AttributeType.Value != AttributeTypeCode.Virtual
                    && a.AttributeType.Value != AttributeTypeCode.PartyList
                    && a.IsValidForRead.Value
                    && a.LogicalName.IndexOf("composite") < 0
                    ).OrderBy(a => a.LogicalName))
                {
                    attributes.Add(attribute);

                    var fetchXmlConditionNotNullPart = string.Format(
                        "<condition attribute=\"{0}\" operator=\"not-null\"/>", attribute.LogicalName);
                    emRequest.Requests.Add(new RetrieveMultipleRequest
                    {
                        Query =
                            new FetchExpression(string.Format(FetchXml, emd.LogicalName, fetchXmlAttrPart,
                                fetchXmlConditionNotNullPart))
                    });
                }

                var results = (ExecuteMultipleResponse) service.Execute(emRequest);
               
                var allResponse = (RetrieveMultipleResponse) results.Responses[0].Response;

                if (results.Responses[0].Fault != null)
                {
                    result.IsAggregateQueryRecordLimitReached = results.Responses[0].Fault.ErrorCode == -2147164125;
                    result.Fault = results.Responses[0].Fault;
                    return result;
                }

                var allCount = allResponse != null
                    ? allResponse.EntityCollection.Entities.First().GetAttributeValue<AliasedValue>("count")
                    : null;
                var allCountValue = allCount != null ? (int) allCount.Value : 0;

                result.Total = allCountValue;
                result.Entity = emd.LogicalName;

                foreach (var attribute in attributes)
                {
                    var index = attributes.IndexOf(attribute);
                    var resultNotNull = results.Responses[index + 1];

                    if (resultNotNull.Fault != null)
                    {
                        result.Fault = resultNotNull.Fault;
                        return result;
                    }

                    var notNullValueAliased =
                        ((RetrieveMultipleResponse) resultNotNull.Response).EntityCollection.Entities.First()
                            .GetAttributeValue<AliasedValue>("count");

                    var notNullValue = notNullValueAliased == null ? 0 : (int) notNullValueAliased.Value;

                    result.Results.Add(new DetectionResult
                    {
                        Attribute = attribute,
                        NotNull = notNullValue,
                        Percentage = allCountValue != 0 ? ((double)notNullValue*100)/(double)allCountValue : 0
                    });
                }
            }

            return result;
        }
    }
}
