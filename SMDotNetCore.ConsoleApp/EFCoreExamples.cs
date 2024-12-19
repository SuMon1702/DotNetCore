using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleApp
{
    internal class EFCoreExamples
    {
        public void Run()
        {
            Read();
        }

        private void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Movies.ToList();
            foreach (MovieModel item in lst)
            {
                Console.WriteLine(item.MovieID);
                Console.WriteLine(item.MovieName);
                Console.WriteLine(item.MovieTitle);
                Console.WriteLine(item.MovieContent);
                Console.WriteLine("...........................");

            }
        }


    }
}
