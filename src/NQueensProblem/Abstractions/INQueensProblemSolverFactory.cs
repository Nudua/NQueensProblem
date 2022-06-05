namespace NQueensProblem.Abstractions;

public interface INQueensProblemSolverFactory
{
    INQueensProblemSolver Create(int numberOfQueens = 8);
}
