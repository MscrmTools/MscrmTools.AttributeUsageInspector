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
        private static readonly string[] EntityMetadataProperties = { "LogicalName", "DisplayName", "Attributes", "PrimaryIdAttribute", "ObjectTypeCode", "SchemaName" };
        private static readonly string[] AttributeMetadataProperties = { "DisplayName", "LogicalName", "AttributeType", "IsValidForRead", "AttributeOf", "IsCustomAttribute", "SchemaName" };

        public static EntityMetadataCollection LoadEntities(IOrganizationService service)
        {
            var entityQueryExpression = new EntityQueryExpression()
            {
                Properties = new MetadataPropertiesExpression(EntityMetadataProperties),
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression(AttributeMetadataProperties)
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
                    Properties = new MetadataPropertiesExpression(AttributeMetadataProperties)
                    {
                        AllProperties = false
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

        public static IEnumerable<AttributeMetadata> FilterAttributes(AttributeMetadata[] attributes)
        {
            return attributes.Where(a =>
                            a.AttributeOf == null
                            && a.AttributeType.Value != AttributeTypeCode.Virtual
                            && a.AttributeType.Value != AttributeTypeCode.PartyList
                            && a.IsValidForRead.Value
                            && a.LogicalName.IndexOf("composite") < 0
                            ).OrderBy(a => a.LogicalName);
        }
    }
}