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
    public class ApplicationsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        readonly BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public bool IsAdminUser { get; set; }
        private IEnumerable<Application> Applications { get; set; }
        private IEnumerable<Orchestration> Orchestrations { get; set; }
        private IEnumerable<ReceiveLocation2> ReceiveLocations2 { get; set; }
        private IEnumerable<SendPort> SendPorts { get; set; }
        public List<ApplicationTree> AppTree { get; set; }


        public ApplicationsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task OnGet()
        {
            HttpClient adminApiClient = _api.InitBiztalkAdminAPI();
            HttpClient adminSrvClient = _api.InitBiztalkMgmtSrv();

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
            HttpResponseMessage resOrc = await adminApiClient.GetAsync("Orchestration");
            if (resOrc.IsSuccessStatusCode)
            {
                var resultOrc = resOrc.Content.ReadAsStringAsync().Result;
                Orchestrations = JsonConvert.DeserializeObject<IEnumerable<Orchestration>>(resultOrc);
            }
            HttpResponseMessage resApp = await adminSrvClient.GetAsync("Applications");
            if (resApp.IsSuccessStatusCode)
            {
                var resultApp = resApp.Content.ReadAsStringAsync().Result;
                Applications = JsonConvert.DeserializeObject<IEnumerable<Application>>(resultApp);
                AppTree = new List<ApplicationTree>();                
                foreach(Application app in Applications)
                {
                    AppTree.Add(new ApplicationTree
                    {
                        applicationName = app.Name,
                        orchestrations = Orchestrations.Where(o => o.applicationName == app.Name).ToList(),
                        receiveLocations = ReceiveLocations2.Where(o => o.applicationName == app.Name).ToList(),
                        sendPorts = SendPorts.Where(o => o.applicationName == app.Name).ToList()
                    });                    
                }
            }
        }
    }
}