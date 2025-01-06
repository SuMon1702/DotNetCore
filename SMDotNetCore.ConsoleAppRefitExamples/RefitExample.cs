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
            await ReadAsync();
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
    }
}