using System.Collections.Generic;
using System.Xml;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace MscrmTools.AttributeUsageInspector
{
    class DetectionResults
    {
        private List<XmlDocument> formXmlDocuments;

        public DetectionResults()
        {
            Results = new List<DetectionResult>();
        }

        public int Total { get; set; }
        public OrganizationServiceFault Fault { get; set; }
        public List<DetectionResult> Results { get; private set; }
        public bool IsAggregateQueryRecordLimitReached { get; internal set; }
        public string Entity { get; internal set; }

        public IEnumerable<string> Forms
        {
            set
            {
                if (formXmlDocuments == null)
                {
                    formXmlDocuments = new List<XmlDocument>();
                }

                foreach (var form in value)
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(form);
                    formXmlDocuments.Add(xmlDocument);
                }
            }
        }

        public bool AttributeIsContainedInForms(string attributeLogicalName)
        {
            foreach (var formXml in formXmlDocuments)
            {
                var controlNode = formXml.SelectSingleNode("//control[@datafieldname='" + attributeLogicalName + "']");
                if (controlNode != null)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class DetectionResult
    {
        public int NotNull { get; set; }
        public double Percentage { get; set; }
        public AttributeMetadata Attribute { get; set; }
    }
}
