﻿using SMDotNetCore.ConsoleAppHttpClientExamples;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //HttpClient client = new HttpClient();

        //{
        //    var response = await client.GetAsync("https://localhost:7294/api/MovieEFCore");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string jsonStr = await response.Content.ReadAsStringAsync();
        //        List<MovieModel> lst = JsonConvert.DeserializeObject<List<MovieModel>>(jsonStr)!;

        //        foreach (var movie in lst)
        //        {
        //            Console.WriteLine(JsonConvert.SerializeObject(movie));
        //            Console.WriteLine($"Name=>{movie.MovieName}");
        //            Console.WriteLine($"Title=>{movie.MovieTitle}");
        //            Console.WriteLine($"Content=>{movie.MovieContent}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Failed to get data");
        //    }



        HttpClientExample httpClientExample = new HttpClientExample();
        await httpClientExample.RunAsync();

        Console.ReadLine();
    }
}