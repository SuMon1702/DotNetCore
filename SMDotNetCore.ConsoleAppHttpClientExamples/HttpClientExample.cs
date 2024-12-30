using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SMDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7294") };
        private readonly string _blogEndpoint = "/api/MovieEFCore";
        public async Task RunAsync()
        {
            await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(11);

            //await CreateAsync("John", "Action", "Watch");
            // await UpdateAsync(1, "BabyJohn", "Action", "Watch");
          //await DeleteAsync(2030);
        }


        private async Task ReadAsync()
        {
            try
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
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
        }

        private async Task EditAsync(int id)
        {
            try
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
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
        }


        private async Task CreateAsync(string name, string title, string content)
        {
            MovieModel movieModel = new MovieModel()
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content
            };

            string blogJson = JsonConvert.SerializeObject(movieModel);
            HttpContent httpContent= new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndpoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
               string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Failed to create");
            }
        }


        private async Task UpdateAsync(int id, string name, string title, string content)
        {
            MovieModel movieModel = new MovieModel()
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content
            };

            string blogJson = JsonConvert.SerializeObject(movieModel);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Failed to update");
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                //other process
                //continue
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                //error message
                //continue
            }
        }





























    }
}



    
    

