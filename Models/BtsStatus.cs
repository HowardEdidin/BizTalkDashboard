using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class BtsStatus
    {
        [DisplayName("Host instances running")]
        public int hostInstancesRunning { get; set; }
        [DisplayName("Host instances stopped")]
        public int hostInstancesNotRunning { get; set; }
        [DisplayName("Enabled receive location count")]
        public int receiveLocationsEnabled { get; set; }
        [DisplayName("Disabled receive location count")]
        public int receiveLocationsDisabled { get; set; }
        [DisplayName("Suspended instances count")]
        public int suspendedInstancesCount { get; set; }
        [DisplayName("Running instances count")]
        public int runningInstancesCount { get; set; }
        
    }

}
