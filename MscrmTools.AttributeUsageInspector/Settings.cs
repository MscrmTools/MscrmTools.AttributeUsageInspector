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
        public IDictionary<string, EntityFilterSetting> Filters { get; } = new Dictionary<string, EntityFilterSetting>();
    }
}