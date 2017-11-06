using System.Collections.Generic;
using System.Xml.Serialization;

namespace MscrmTools.AttributeUsageInspector
{
    public class Settings
    {
        private int recordsReturnedPerTrip;

        public int RecordsReturnedPerTrip
        {
            get => recordsReturnedPerTrip;
            set => recordsReturnedPerTrip = value > 5000 ? 5000 : value;
        }

        public int AttributesReturnedPerTrip { get; set; }
        public bool FilterAttributes { get; set; }

        [XmlIgnore]
        public List<string> Attributes { get; set; }

        [XmlIgnore]
        public bool ShowOnlyCustom { get; set; }

        [XmlIgnore]
        public bool ShowOnlyStandard { get; set; }
    }
}