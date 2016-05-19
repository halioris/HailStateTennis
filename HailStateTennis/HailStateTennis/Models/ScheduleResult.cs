using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HailStateTennis
{
    public class ScheduleResult
    {
        public int ID { get; set; }
        public string Result { get; set; }
        //public List<MatchResult> Doubles { get; set; }
        //public List<MatchResult> Singles { get; set; }
        //public List<SectionResult> Section { get; set; }
        public List<DayResult> DayResults { get; set; }
        //public string Order { get; set; }
    }
}
