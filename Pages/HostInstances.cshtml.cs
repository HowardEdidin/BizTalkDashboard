using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using BizTalkDashboard.Helpers;
using BizTalkDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BizTalkDashboard
{
    public class HostInstancesModel : PageModel
    {
        private readonly IConfiguration _configuration;
        readonly BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public IEnumerable<HostInstance> HostInstances { get; private set; }
        public bool GetHostInstancesError { get; private set; }
        public bool IsAdminUser { get; set; }

        public HostInstancesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGet(string hostname, string servername, string state)
        {
            HttpClient client = _api.InitBiztalkAdminAPI();

            if (!String.IsNullOrEmpty(hostname) || !String.IsNullOrEmpty(servername) || !String.IsNullOrEmpty(state))
            {
                string tostate;

                if (state == "Running")
                    tostate = "Stop";
                else
                    tostate = "Start";

                HttpResponseMessage resStop = await client.PutAsync("HostInstance/" + servername + "/" + hostname + "/" + tostate, null);
                if (resStop.IsSuccessStatusCode)
                {
                    _ = resStop.Content.ReadAsStringAsync().Result;
                }
            }
            
            HttpResponseMessage res = await client.GetAsync("HostInstance");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                HostInstances = JsonConvert.DeserializeObject<IEnumerable<HostInstance>>(result);

            }

            IsAdminUser = Security.IsInGroup(User, _configuration["AdminADGroup"]);
        }

    }
}