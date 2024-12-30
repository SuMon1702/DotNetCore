using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7294") };
        private readonly string _blogEndpoint = "/api/MovieEFCore";
        public async Task RunAsync()
        {
            await ReadAsync();
        }

        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<MovieModel> lst = JsonConvert.DeserializeObject<List<MovieModel>>(jsonStr)!;

                foreach (var movie in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(movie));
                    Console.WriteLine($"Name=>{movie.MovieName}");
                    Console.WriteLine($"Title=>{movie.MovieTitle}");
                    Console.WriteLine($"Content=>{movie.MovieContent}");
                }
            }
            else
            {
                Console.WriteLine("Failed to get data");
            }
        }
    }
}



    
    

