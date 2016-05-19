using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public class DayResult
    {
        public string Day { get; set; }
        public string Order { get; set; }
        public List<SectionResult> Section { get; set; }
    }
}