using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace MscrmTools.AttributeUsageInspector
{
    internal class DetectiveEngine
    {
        private const string FetchXml = "<fetch mapping=\"logical\" aggregate=\"true\" count=\"{3}\"><entity name=\"{0}\">{1}<filter>{2}</filter></entity></fetch>";
        private readonly IOrganizationService service;

        public DetectiveEngine(IOrganizationService service)
        {
            this.service = service;
        }

        public bool Cancel { get; set; }

        private DetectionResults GetUsageStdQuery(EntityMetadata emd, Settings settings, BackgroundWorker worker = null)
        {
            var result = new DetectionResults();

            List<AttributeMetadata> attributes = new List<AttributeMetadata>();

            
            ColumnSet columnSet = null;
            if (settings.Filters.ContainsKey(emd.LogicalName) &&
                settings.Filters[emd.LogicalName].Attributes.Count > 0)
            {
                columnSet = new ColumnSet(settings.Filters[emd.LogicalName].Attributes.ToArray());
            }
            else
            {
                columnSet = new ColumnSet(MetadataHelper.FilterAttributes(emd.Attributes).Select(a => a.LogicalName).ToArray());
            }
            var query = new QueryExpression(emd.LogicalName)
            {
                PageInfo = new PagingInfo
                {
                    Count = settings.RecordsReturnedPerTrip,
                    PageNumber = 1
                },
                ColumnSet = columnSet,
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
                    foreach (var attribute in MetadataHelper.FilterAttributes(emd.Attributes).OrderBy(a => a.LogicalName))
                    {
                        if (!record.Contains(attribute.LogicalName)) continue;
                        if (settings.FilterAttributes &&
                            settings.Filters.ContainsKey(record.LogicalName))
                        {
                            EntityFilterSetting fs = settings.Filters[record.LogicalName];
                            if (fs.Attributes.Count > 0 &&
                                !fs.Attributes.Contains(attribute.LogicalName)) continue;
                            if (fs.ShowOnlyCustom && !attribute.IsCustomAttribute.Value) continue;
                            if (fs.ShowOnlyStandard && attribute.IsCustomAttribute.Value) continue;
                        }
                        if (!attributesCount.ContainsKey(attribute))
                        {
                            attributesCount.Add(attribute, 0);
                        }
                        attributesCount[attribute] = attributesCount[attribute] + 1;
                    }
                }
            } while (ec.MoreRecords && Cancel == false);

            result.Total = total;
            result.Entity = emd.LogicalName;

            foreach (var key in attributesCount.Keys)
            {
                result.Results.Add(new DetectionResult
                {
                    Attribute = key,
                    NotNull = attributesCount[key],
                    Percentage = result.Total != 0 ? attributesCount[key] * 100 / (double)result.Total : 0
                });
            }

            return result;

        }
        private DetectionResults GetUsageFetchAggregate(EntityMetadata emd, Settings settings, BackgroundWorker worker = null)
        {
            var result = new DetectionResults();

            List<AttributeMetadata> attributes = new List<AttributeMetadata>();

            var emRequest = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            var fetchXmlAttrPart = $"<attribute name=\"{emd.PrimaryIdAttribute}\" aggregate=\"count\" alias=\"count\"/>";
            emRequest.Requests.Add(new RetrieveMultipleRequest
            {
                Query = new FetchExpression(string.Format(FetchXml, emd.LogicalName, fetchXmlAttrPart, "", settings.RecordsReturnedPerTrip))
            });

            var allResult = new ExecuteMultipleResponseItemCollection();

            foreach (var attribute in MetadataHelper.FilterAttributes(emd.Attributes).OrderBy(a => a.LogicalName))
            {

                if (settings.FilterAttributes &&
                    settings.Filters.ContainsKey(emd.LogicalName))
                {
                    EntityFilterSetting fs = settings.Filters[emd.LogicalName];
                    if (fs.Attributes.Count > 0 &&
                        !fs.Attributes.Contains(attribute.LogicalName)) continue;
                    if (fs.ShowOnlyCustom && !attribute.IsCustomAttribute.Value) continue;
                    if (fs.ShowOnlyStandard && attribute.IsCustomAttribute.Value) continue;
                }

                attributes.Add(attribute);

                var fetchXmlConditionNotNullPart = $"<condition attribute=\"{attribute.LogicalName}\" operator=\"not-null\"/>";
                emRequest.Requests.Add(new RetrieveMultipleRequest
                {
                    Query =
                        new FetchExpression(string.Format(FetchXml, emd.LogicalName, fetchXmlAttrPart,
                            fetchXmlConditionNotNullPart, settings.RecordsReturnedPerTrip))
                });

                if (emRequest.Requests.Count == settings.AttributesReturnedPerTrip)
                {
                    var tempResults = (ExecuteMultipleResponse)service.Execute(emRequest);
                    allResult.AddRange(tempResults.Responses);

                    emRequest = new ExecuteMultipleRequest
                    {
                        Settings = new ExecuteMultipleSettings
                        {
                            ContinueOnError = true,
                            ReturnResponses = true
                        },
                        Requests = new OrganizationRequestCollection()
                    };
                }
            }

            var results = (ExecuteMultipleResponse)service.Execute(emRequest);
            allResult.AddRange(results.Responses);

            var allResponse = (RetrieveMultipleResponse)allResult[0].Response;

            if (allResult[0].Fault != null)
            {
                result.IsAggregateQueryRecordLimitReached = allResult[0].Fault.ErrorCode == -2147164125;
                result.Fault = allResult[0].Fault;
                return result;
            }

            var allCount = allResponse != null
                ? allResponse.EntityCollection.Entities.First().GetAttributeValue<AliasedValue>("count")
                : null;
            var allCountValue = allCount != null ? (int)allCount.Value : 0;

            result.Total = allCountValue;
            result.Entity = emd.LogicalName;

            foreach (var attribute in attributes)
            {
                var index = attributes.IndexOf(attribute);
                var resultNotNull = allResult[index + 1];

                if (resultNotNull.Fault != null)
                {
                    result.Fault = resultNotNull.Fault;
                    return result;
                }

                var notNullValueAliased =
                    ((RetrieveMultipleResponse)resultNotNull.Response).EntityCollection.Entities.First()
                        .GetAttributeValue<AliasedValue>("count");

                var notNullValue = (int?)notNullValueAliased?.Value ?? 0;

                result.Results.Add(new DetectionResult
                {
                    Attribute = attribute,
                    NotNull = notNullValue,
                    Percentage = allCountValue != 0 ? (double)notNullValue * 100 / allCountValue : 0
                });
            }

            return result;
        }


        private DetectionResults GetUsageSQLCount(EntityMetadata emd, Settings settings, BackgroundWorker worker = null)
        {
            var result = new DetectionResults();
            if (!string.IsNullOrEmpty(settings.SQLConnectionString))
            {
                List<AttributeMetadata> attributes = new List<AttributeMetadata>();

                foreach (var attribute in MetadataHelper.FilterAttributes(emd.Attributes).OrderBy(a => a.LogicalName))
                {

                    if (settings.FilterAttributes &&
                        settings.Filters.ContainsKey(emd.LogicalName))
                    {
                        EntityFilterSetting fs = settings.Filters[emd.LogicalName];
                        if (fs.Attributes.Count > 0 &&
                            !fs.Attributes.Contains(attribute.LogicalName)) continue;
                        if (fs.ShowOnlyCustom && !attribute.IsCustomAttribute.Value) continue;
                        if (fs.ShowOnlyStandard && attribute.IsCustomAttribute.Value) continue;
                    }

                    attributes.Add(attribute);
                }

                string tablename = "dbo." + emd.SchemaName;

                string sqlrequesttemplate = "SELECT count(*) as total{0} from {1}";
                string fieldsquery = "";
                if (attributes.Count() > 0)
                    fieldsquery = ", " + string.Join(",", attributes.Select(a => "count(" + a.SchemaName + ") as " + a.LogicalName));
                string sqlrequest = string.Format(sqlrequesttemplate, fieldsquery, tablename);

                using (SqlConnection connection = new SqlConnection(settings.SQLConnectionString))
                {
                    SqlCommand command = new SqlCommand(sqlrequest, connection);
                    command.CommandTimeout = settings.SQLCommandTimeout;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Entity = emd.LogicalName;
                            result.Total = int.Parse(reader["total"].ToString());

                            foreach (var attribute in attributes)
                            {
                                double notNullValue = double.Parse(reader[attribute.LogicalName].ToString());
                                result.Results.Add(new DetectionResult
                                {
                                    Attribute = attribute,
                                    NotNull = Convert.ToInt32(notNullValue),
                                    Percentage = result.Total != 0 ? (double)notNullValue * 100 / result.Total : 0
                                });

                            }
                        }
                    }
                }
            }

            return result;
        }

        public DetectionResults GetUsage(EntityMetadata emd, bool useStdQueries, Settings settings, BackgroundWorker worker = null)
        {
            if (useStdQueries)
            {
                if (settings.UseSQLQuery)
                {
                    return GetUsageSQLCount(emd, settings, worker);
                }
                else
                {
                    return GetUsageStdQuery(emd, settings, worker);
                }
            }
            else
            {
                return GetUsageFetchAggregate(emd, settings, worker);
            }

        }
    }
}