using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MscrmTools.AttributeUsageInspector
{
    public class EntityFilterSetting
    {
        public List<string> Attributes { get; set; }

        public bool ShowOnlyCustom { get; set; }

        public bool ShowOnlyStandard { get; set; }
    }
}
