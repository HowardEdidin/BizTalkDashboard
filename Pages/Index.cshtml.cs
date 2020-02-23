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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BizTalkDashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        BizTalkAPIHelper _api = new BizTalkAPIHelper();
        public BtsStatus btsStatus { get; private set; }
        public ViewSettings viewSettings { get; set; }
        
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task OnGet()
        {
            HttpClient client = _api.InitBiztalkAdminAPI();

            HttpResponseMessage res = await client.GetAsync("BizTalkStatus");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                btsStatus = JsonConvert.DeserializeObject<BtsStatus>(result);
                
            }

            viewSettings = _configuration.GetSection("ViewSettings").Get<ViewSettings>();

        }
    }
}
