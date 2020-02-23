using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class ViewSettings
    {
        public int suspendedWarningThreshold { get; set; }
        public int suspendedDangerThreshold { get; set; }
        public int runningInstWarningThreshold { get; set; }
        public int runningInstDangerThreshold { get; set; }
    }
}
