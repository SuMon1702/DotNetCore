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
        }

        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_movieEndpoint, Method.Get);
            var response = await _restClient.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<MovieModel> lst = JsonConvert.DeserializeObject<List<MovieModel>>(jsonStr)!;
                foreach(var item in lst)
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

        }


    }
}
