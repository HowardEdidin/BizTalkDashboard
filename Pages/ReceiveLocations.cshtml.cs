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
    public class ReceiveLocationsModel : PageModel
    {
        private readonly IConfiguration _configuration;
        readonly BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public IEnumerable<ReceiveLocation> ReceiveLocations { get; private set; }
        public bool IsAdminUser { get; set; }

        public ReceiveLocationsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGet(string receivePort, string receiveLocation, string state)
        {
            HttpClient client = _api.InitBiztalkMgmtSrv();

            if (!String.IsNullOrEmpty(receivePort) || !String.IsNullOrEmpty(receiveLocation) || !String.IsNullOrEmpty(state))
            {
                HttpResponseMessage resStop = await client.PutAsync("ReceiveLocations/" + state + "/" + receivePort + "/" + receiveLocation, null);
                if (resStop.IsSuccessStatusCode)
                {
                    _ = resStop.Content.ReadAsStringAsync().Result;
                }
            }

            HttpResponseMessage res = await client.GetAsync("ReceiveLocations");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                ReceiveLocations = JsonConvert.DeserializeObject<IEnumerable<ReceiveLocation>>(result);

            }

            IsAdminUser = Security.IsInGroup(User, _configuration["AdminADGroup"]);
        }
    }
}