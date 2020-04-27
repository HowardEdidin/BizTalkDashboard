using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class Application
    {
        public string Name { get; set; }        
    }

    public class ApplicationTree
    {
        public string applicationName { get; set; }
        public List<Orchestration> orchestrations { get; set; }
        public List<ReceiveLocation2> receiveLocations { get; set; }
        public List<SendPort> sendPorts { get; set; }
    }
}
