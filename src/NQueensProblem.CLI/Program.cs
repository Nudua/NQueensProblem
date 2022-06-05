using BenchmarkDotNet.Running;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NQueensProblem.Abstractions;
using NQueensProblem.Benchmarks;
using NQueensProblem.Factory;

// Setup DI and logging
var serviceProvider = new ServiceCollection()
    .AddSingleton<INQueensProblemSolverFactory, NQueensProblemSolverFactory>()
    .AddLogging(options =>
    {
        options.ClearProviders();
        options.AddConsole();
        options.SetMinimumLevel(LogLevel.Debug);
    })
    .BuildServiceProvider();

switch (args.Length)
{
    case 1 when args[0] == "-b" || args[0] == "--benchmark":
        {
            Console.WriteLine("Starting benchmark...");
            BenchmarkRunner.Run<BacktrackingNQueensProblemSolverBenchmarks>();
        }
        break;
    case 2 when (args[0] == "-s" || args[0] == "--solve") && int.TryParse(args[1], out var numberOfQueens):
        {
            var factory = serviceProvider.GetRequiredService<INQueensProblemSolverFactory>();
            var problemSolver = factory.Create(numberOfQueens);

            var solutions = problemSolver.Solve();

            Console.WriteLine($"{solutions.Count} solutions to the {numberOfQueens}-queens problem was found.");
        }
        break;
    default:
        PrintUsage();
        break;
}

static void PrintUsage()
{
    Console.WriteLine("This program solves the N-Queens Problem or benchmarks the algorithm used to solve it.");
    Console.WriteLine("Usage:");
    Console.WriteLine("NQueensProblemSolver.CLI.exe [options]");
    Console.WriteLine("NQueensProblemSolver.CLI.exe");
    Console.WriteLine("Options:");
    Console.WriteLine("  -s|--solve [numberOfQueens]     Solve");
    Console.WriteLine("  -b|--benchmark                  Benchmark the algorithm used to solve the problem.");
}
