using System;

namespace BizTalkDashboard.Models
{
    public class Orchestration
    {
        public string applicationName { get; set; }
        public string orchestrationName { get; set; }
        public string orchestrationStatus { get; set; }
        public DateTime? lastStartDateTime { get; set; }

    }
}