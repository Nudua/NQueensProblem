using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NQueensProblem.Abstractions;
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
    Console.WriteLine("This program solves the N-Queens Problem.");
    Console.WriteLine("Usage:");
    Console.WriteLine("NQueensProblemSolver.CLI.exe [options]");
    Console.WriteLine("NQueensProblemSolver.CLI.exe");
    Console.WriteLine("Options:");
    Console.WriteLine("  -s|--solve [numberOfQueens]     Solve");
}
