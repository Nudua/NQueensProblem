using NQueensProblem.Abstractions;

namespace NQueensProblem.Factory;

public class NQueensProblemSolverFactory : INQueensProblemSolverFactory
{
    public INQueensProblemSolver Create(int numberOfQueens = 8)
    {
        if (numberOfQueens < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfQueens));
        }

        return new BacktrackingNQueensProblemSolver(numberOfQueens);
    }
}
