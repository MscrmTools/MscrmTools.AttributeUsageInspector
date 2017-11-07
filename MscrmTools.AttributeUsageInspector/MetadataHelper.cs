using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;

namespace MscrmTools.AttributeUsageInspector
{
    /// <summary>
    /// Class for querying Crm Metadata
    /// </summary>
    internal class MetadataHelper
    {
        public static EntityMetadataCollection LoadEntities(IOrganizationService service)
        {
            var entityQueryExpression = new EntityQueryExpression()
            {
                Properties = new MetadataPropertiesExpression("LogicalName", "DisplayName", "Attributes", "PrimaryIdAttribute", "ObjectTypeCode"),
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression("DisplayName", "LogicalName", "AttributeType", "IsValidForRead", "AttributeOf", "IsCustomAttribute")
                }
            };
            var retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            return ((RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest)).EntityMetadata;
        }

        public static EntityMetadataCollection LoadAttributes(IOrganizationService service, string entityLogicalName)
        {
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression
            {
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, entityLogicalName)
                    }
                },
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "Attributes" }
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false,
                        PropertyNames = { "DisplayName", "LogicalName", "IsCustomAttribute" }
                    }
                },
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

            return response.EntityMetadata;
        }

        public static IEnumerable<string> GetFormsDefinitions(int objectTypeCode, IOrganizationService service)
        {
            var qe = new QueryExpression("systemform")
            {
                ColumnSet = new ColumnSet("formxml"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.Equal, objectTypeCode),
                        new ConditionExpression("type", ConditionOperator.In, new[] {2, 7})
                    }
                }
            };

            return service.RetrieveMultiple(qe).Entities.Select(e => e.GetAttributeValue<string>("formxml"));
        }
    }
}