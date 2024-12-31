using Newtonsoft.Json;
using RestSharp;

namespace SMDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExamples
    {
        private readonly RestClient _restClient = new RestClient(new Uri("https://localhost:7294"));
        private readonly string _movieEndpoint = "/api/MovieEFCore";

        public async Task RunAsync()
        {
            await ReadAsync();
            await EditAsync(1);
            await EditAsync(11);
            await DeleteAsync(2030);
        }

        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_movieEndpoint, Method.Get);
            var response = await _restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<MovieModel> lst = JsonConvert.DeserializeObject<List<MovieModel>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Name=>{item.MovieName}");
                    Console.WriteLine($"Title=>{item.MovieTitle}");
                    Console.WriteLine($"Content=>{item.MovieContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_movieEndpoint}/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<MovieModel>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Name=>{item.MovieName}");
                Console.WriteLine($"Title=>{item.MovieTitle}");
                Console.WriteLine($"Content=>{item.MovieContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine($"Failed to get data: {message}");
            }
        }

        private async Task CreateAsync(string name, string title, string author)
        {
            MovieModel movieModel = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = author
            };
            var restRequest = new RestRequest(_movieEndpoint, Method.Post);
            restRequest.AddJsonBody(movieModel);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine($"Data created: {message}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine($"Failed to create data: {message}");
            }
        }

        private async Task UpdateAsync(int id, string name, string title, string author)
        {
            MovieModel movieModel = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = author
            };
            var restRequest = new RestRequest($"{_movieEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(movieModel);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine($"Data updated: {message}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine($"Failed to update data: {message}");
            }
        }

            private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_movieEndpoint}/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine($"Data deleted: {message}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine($"Failed to delete data: {message}");
            }
        }
    }
}