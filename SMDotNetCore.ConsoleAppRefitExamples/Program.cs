using SMDotNetCore.ConsoleAppRefitExamples;

internal class Program
{
    private static async Task Main(string[] args)
    {
        RefitExample refitExample = new RefitExample();
        await refitExample.RunAsync();
    }
}