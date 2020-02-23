using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class HostInstance
    {
        public string Caption { get; set; }
        public string ClusterInstanceType { get; set; }
        public string ConfigurationState { get; set; }
        public string Description { get; set; }
        [DisplayName("Host name")]
        public string HostName { get; set; }
        [DisplayName("Type")]
        public string HostType { get; set; }
        public string InstallDate { get; set; }
        public string IsDisabled { get; set; }
        public string Logon { get; set; }
        public string MgmtDbNameOverride { get; set; }
        public string MgmtDbServerOverride { get; set; }
        public string Name { get; set; }
        public string NTGroupName { get; set; }
        public string RunningServer { get; set; }
        [DisplayName("Host state")]
        public string ServiceState { get; set; }
        public string Status { get; set; }
        public string UniqueID { get; set; }
    }
}
