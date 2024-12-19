using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMDotNetCore.ConsoleApp
{
    internal class EFCoreExamples
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(5);
            //Edit(25);
            // Create("Princess", "Fiction", "Go");
            // Update(5, "SetIt", "Romance", "WatchIt");
            Delete(2);

        }

        private void Read()
        {
            
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

        private void Edit(int id)
        {
            var item =db.Movies.FirstOrDefault(x => x.MovieID == id);
            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(item.MovieID);
            Console.WriteLine(item.MovieName);
            Console.WriteLine(item.MovieTitle);
            Console.WriteLine(item.MovieContent);
        }

        private void Create(string name, string title, string content)
        {
            var item = new MovieModel
            {
                MovieName = name,
                MovieTitle = title,
                MovieContent = content
            };

            db.Movies.Add(item);
            int result= db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        private void Update(int id, string name, string title, string content)
        {
            var item= db.Movies.FirstOrDefault(x=>x.MovieID == id);
            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            item.MovieName = name;
            item.MovieTitle = title;
            item.MovieContent = content;

            int result= db.SaveChanges();

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Movies.FirstOrDefault(x => x.MovieID == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            db.Movies.Remove(item);
            int result= db.SaveChanges();

            string message = result > 0 ? "Deleting Successful" : "Updating Failed";
            Console.WriteLine(message);

        }


    }
}
