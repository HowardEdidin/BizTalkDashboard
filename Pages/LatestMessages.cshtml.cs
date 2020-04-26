using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BizTalkDashboard.Helpers;
using BizTalkDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BizTalkDashboard
{
    public class LatestMessagesModel : PageModel
    {
        private readonly IConfiguration _configuration;
        readonly BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public bool IsAdminUser { get; set; }
        public IEnumerable<ReceiveLocation2> ReceiveLocations2 { get; private set; }
        public IEnumerable<SendPort> SendPorts { get; private set; }

        public LatestMessagesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task OnGet()
        {
            HttpClient adminApiClient = _api.InitBiztalkAdminAPI();

            HttpResponseMessage resRL = await adminApiClient.GetAsync("ReceiveLocation");
            if (resRL.IsSuccessStatusCode)
            {
                var resultRL = resRL.Content.ReadAsStringAsync().Result;
                ReceiveLocations2 = JsonConvert.DeserializeObject<IEnumerable<ReceiveLocation2>>(resultRL);
            }
            HttpResponseMessage resSP = await adminApiClient.GetAsync("SendPort");
            if (resSP.IsSuccessStatusCode)
            {
                var resultSP = resSP.Content.ReadAsStringAsync().Result;
                SendPorts = JsonConvert.DeserializeObject<IEnumerable<SendPort>>(resultSP);
            }
        }
    }
}