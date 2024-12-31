using SMDotNetCore.ConsoleAppRestClientExamples;

Console.WriteLine("Hello, World!");
RestClientExamples restClientExamples = new RestClientExamples();
await restClientExamples.RunAsync();

Console.ReadLine();
