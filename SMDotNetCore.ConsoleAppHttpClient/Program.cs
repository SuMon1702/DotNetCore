
Console.WriteLine("Hello, World!");

string jsonStr= await File.ReadAllTextAsync("data.json");
Console.WriteLine(jsonStr);

Console.ReadKey();
