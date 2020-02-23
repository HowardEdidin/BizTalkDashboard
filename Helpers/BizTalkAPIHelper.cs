using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BizTalkDashboard.Helpers
{
    public class BizTalkAPIHelper
    {
        public HttpClient InitBiztalkAdminAPI()
        {
            var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            client.BaseAddress = new Uri("http://localhost/BizTalkAdminAPI/");
            return client;
        }

        public HttpClient InitBiztalkMgmtSrv()
        {
            var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            client.BaseAddress = new Uri("http://localhost/BizTalkManagementService/");
            return client;
        }


    }
}
