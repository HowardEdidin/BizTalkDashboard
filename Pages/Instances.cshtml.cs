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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BizTalkDashboard
{
    public class InstancesModel : PageModel
    {
        private readonly IConfiguration _configuration;
        readonly BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public IEnumerable<Instances> Instances { get; private set; }
    
        public bool IsAdminUser { get; set; }

        public InstancesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGetAsync(int p = 1)
        {
            
            HttpClient client = _api.InitBiztalkMgmtSrv(); 
            
            HttpResponseMessage res = await client.GetAsync("OperationalData/Instances");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Instances = JsonConvert.DeserializeObject<IEnumerable<Instances>>(result);

            }

            IsAdminUser = Security.IsInGroup(User, _configuration["AdminADGroup"]);
        }

    
    }
}