using BenchmarkDotNet.Attributes;

namespace NQueensProblem.Benchmarks;

[MemoryDiagnoser]
public class BacktrackingNQueensProblemSolverBenchmarks
{
    [Benchmark]
    public List<int[]> BacktrackingEightQueensBenchmark()
    {
        var eightQueensSolver = new BacktrackingNQueensProblemSolver(8);
        return eightQueensSolver.Solve();
    }

    [Benchmark]
    public List<int[]> BacktrackingFiveQueensBenchmark()
    {
        var fiveQueensSolver = new BacktrackingNQueensProblemSolver(5);
        return fiveQueensSolver.Solve();
    }

    [Benchmark]
    public List<int[]> BacktrackingThreeQueensBenchmark()
    {
        var threeQueensSolver = new BacktrackingNQueensProblemSolver(3);
        return threeQueensSolver.Solve();
    }

    // TODO: Benchmark other implementations to compare them
}
