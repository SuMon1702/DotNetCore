using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleAppRefitExamples
{
    internal class RefitExample
    {
        private readonly IMovieAPI _service = RestService.For<IMovieAPI>("https://localhost:7010");

        public async Task RunAsync()
        {
            //await ReadAsync();
            await EditAsync(12);
            await EditAsync(100);
        }


        private async Task ReadAsync()
        {
            var lst = await _service.GetMovies();
            foreach (var item in lst)
            {
                Console.WriteLine($"MovieID: {item.MovieID}");
                Console.WriteLine($"MovieName: {item.MovieName}");
                Console.WriteLine($"MovieTitle: {item.MovieTitle}");
                Console.WriteLine($"MovieContent: {item.MovieContent}");
                Console.WriteLine(".......................");
            }

        }

        private async Task EditAsync(int id)
        {
            // Refit.ApiException: 'Response status code does not indicate success: 404 (Not Found).'
            try
            {
                var item = await _service.GetMovie(id);
                Console.WriteLine($"MovieID: {item.MovieID}");
                Console.WriteLine($"MovieName: {item.MovieName}");
                Console.WriteLine($"MovieTitle: {item.MovieTitle}");
                Console.WriteLine($"MovieContent: {item.MovieContent}");
                Console.WriteLine(".......................");
            }

            //dii catch ka movie Controller htl ka no data found msg ko pya mr
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }

            // thu ka Response status code does not indicate success: 404 (Not Found) pya dl
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}