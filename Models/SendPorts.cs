using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class SendPort
    {
        [DisplayName("Application")]
        public string applicationName { get; set; }
        [DisplayName("Sendport")]
        public string sendPortName { get; set; }
        [DisplayName("Status")]
        public string portStatus { get; set; }
        [DisplayName("Last message sent")]
        public DateTime? lastMessageSentDatetime { get; set; }
    }
}
