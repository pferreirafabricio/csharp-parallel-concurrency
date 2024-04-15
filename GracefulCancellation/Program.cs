using System.Diagnostics;
using GracefulCancellation;

var path = "random.txt";
var tokenSource = new CancellationTokenSource();
var textGenerationService = new TextGenerationService();
var stopWatch = Stopwatch.StartNew();

try
{
    var fileWriter = textGenerationService.GenerateTextFileAsync(path, 700, tokenSource.Token);

    Console.WriteLine("Processing the operation, please await...");
    Console.WriteLine("If you wish to cancel the operation, Ctrl-C to end.");

    Console.CancelKeyPress += (sender, eventArgs) =>
    {
        Console.WriteLine("Cancel event triggered.");
        tokenSource.Cancel();
        eventArgs.Cancel = true;
    };

    await fileWriter;
    Console.WriteLine("Ended interaction.");
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation cancelled.");
}
finally
{
    tokenSource.Dispose();
    stopWatch.Stop();
    File.Delete(path);

    Console.WriteLine($"Elapsed time: {stopWatch.Elapsed}.");
}