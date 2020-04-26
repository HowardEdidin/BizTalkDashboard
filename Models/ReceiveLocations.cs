using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BizTalkDashboard.Models
{
    public class ReceiveLocation2
    {
        [DisplayName("Application")]
        public string applicationName { get; set; }
        [DisplayName("Receive port")]
        public string receivePortName { get; set; }
        [DisplayName("Receive location")]
        public string receiveLocationName { get; set; }
        [DisplayName("Disabled")]
        public bool disabled { get; set; }
        [DisplayName("Last message received")]
        public DateTime? lastMessageReceivedDateTime { get; set; }
    }
    
    
    public class ReceiveLocation
    {
        [DisplayName("Rloc name")]
        public string Name { get; set; }
        public object Description { get; set; }
        [DisplayName("Receive port name")]
        public string ReceivePortName { get; set; }
        [DisplayName("Enabled")]
        public bool Enable { get; set; }
        public bool IsPrimary { get; set; }
        public string Address { get; set; }
        public string PublicAddress { get; set; }
        [DisplayName("Transport type")]
        public string TransportType { get; set; }
        public string TransportTypeData { get; set; }
        public string ReceiveHandler { get; set; }
        public object CustomData { get; set; }
        public string ReceivePipeline { get; set; }
        public object ReceivePipelineData { get; set; }
        public object SendPipeline { get; set; }
        public object SendPipelineData { get; set; }
        public Schedule Schedule { get; set; }
        public object EncryptionCert { get; set; }
        public string FragmentMessages { get; set; }
    }

    public class Schedule
    {
        public DateTime StartDate { get; set; }
        public bool StartDateEnabled { get; set; }
        public DateTime EndDate { get; set; }
        public bool EndDateEnabled { get; set; }
        public bool ServiceWindowEnabled { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }

}
