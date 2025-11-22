using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public class HttpClientService
    {
        public HttpClient HttpClient { get; set; }
        public HttpClientService() 
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
        }
    }
}
