using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExamples
    {
        private readonly RestClient _restClient = new RestClient(new Uri("https://localhost:7294"));
        private readonly string _movieEndpoint = "/api/MovieEFCore";

        public async Task RunAsync()
        {
            
        }

    }
}
