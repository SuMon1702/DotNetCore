using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleAppRefitExamples
{
    public class RefitExample
    {
        private readonly IMovieAPI _service = RestService.For<IMovieAPI>("https://localhost:7010");

        public async Task RunAsync()
        {
            await ReadAsync();
            // await EditAsync(12);
            // await EditAsync(100);
            //  await CreateAsync("Jonny", "Jonny Title", "Jonny Content");
            //  await UpdateAsync(12, "Puspa_2", "Jonny Title", "Jonny Content");
            // await EditAsync(12);
           // await DeleteAsync(12);
            
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

        private async Task CreateAsync(string name, string title, string content)
        {
            var movie = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content,
            };

            var result = await _service.CreateMovie(movie);
            Console.WriteLine(result);
        }

        private async Task UpdateAsync(int id, string name, string title, string content)
        {
            var movie = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content,
            };

            var result = await _service.UpdateMovie(id, movie);
            Console.WriteLine(result);
        }

        private async Task DeleteAsync(int id)
        {
            var result = await _service.DeleteMovie(id);
            Console.WriteLine(result);
        }
    }
}