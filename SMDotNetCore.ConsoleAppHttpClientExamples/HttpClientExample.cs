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
            //await ReadAsync();
            await EditAsync(1);
            await EditAsync(11);
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

        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                MovieModel movie = JsonConvert.DeserializeObject<MovieModel>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(movie));
                Console.WriteLine($"Name=>{movie.MovieName}");
                Console.WriteLine($"Title=>{movie.MovieTitle}");
                Console.WriteLine($"Content=>{movie.MovieContent}");
            }
            else
            {
               string message= await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        

























    }
}



    
    

