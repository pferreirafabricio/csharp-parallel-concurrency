using System;

/// <summary>
/// The number of additional worker threads that can be started
/// </summary>
int worker = 0;

/// <summary>
/// The number of additional asynchronous I/O threads that can be started
/// </summary>
int io = 0;

int coreCount = 0;

ThreadPool.GetAvailableThreads(out worker, out io);

if (Environment.OSVersion.Platform == PlatformID.Win32NT)
{
#pragma warning disable CA1416 // Validate platform compatibility
    foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
    {
        coreCount += int.Parse(item["NumberOfCores"]?.ToString() ?? "0");
    }
#pragma warning restore CA1416 // Validate platform compatibility
}

Console.WriteLine("Processors {0}.", Environment.ProcessorCount);
Console.WriteLine("Number of cores: {0}", coreCount);
Console.WriteLine("Worker threads: {0:N0}", worker);
Console.WriteLine("Asynchronous I/O threads: {0:N0}", io);