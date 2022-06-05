using NQueensProblem.UnitTests.Data;

namespace NQueensProblem.UnitTests;

public class BacktrackingNQueensProblemSolverTests
{
    private readonly List<int[]> _eightQueensSolutions;
    private readonly List<int[]> _fiveQueensSolutions;

    public BacktrackingNQueensProblemSolverTests()
    {
        _eightQueensSolutions = NQueensSolutions.Get(8);
        _fiveQueensSolutions = NQueensSolutions.Get(5);
    }

    [Fact]
    public void Solve_returns_all_solutions_for_eight_queens_problem()
    {
        var eightQueensProblemSolver = new BacktrackingNQueensProblemSolver(8);

        var solutions = eightQueensProblemSolver.Solve();

        solutions.Should().NotBeNullOrEmpty()
                 .And.HaveCount(92)
                 .And.BeEquivalentTo(_eightQueensSolutions);
    }

    [Fact]
    public void Solve_returns_all_solutions_for_five_queens_problem()
    {
        var fiveQueensProblemSolver = new BacktrackingNQueensProblemSolver(5);

        var solutions = fiveQueensProblemSolver.Solve();

        solutions.Should().NotBeNullOrEmpty()
                 .And.HaveCount(10)
                 .And.BeEquivalentTo(_fiveQueensSolutions);
    }
}
