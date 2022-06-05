using NQueensProblem.Abstractions;

namespace NQueensProblem;

internal class BacktrackingNQueensProblemSolver : INQueensProblemSolver
{
    private readonly int _numberOfQueens;

    private readonly int[] _partialSolve;
    private readonly List<int[]> _solutions = new();

    public BacktrackingNQueensProblemSolver(int numberOfQueens = 8)
    {
        if (numberOfQueens < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfQueens));
        }

        _numberOfQueens = numberOfQueens;
        _partialSolve = new int[_numberOfQueens];
    }

    private bool CanPlaceQueen(int currentRow, int position)
    {
        // Create a slice that consist of the preceeding queen positions up until the position we want to place on
        var slice = _partialSolve[..currentRow];

        // Interate through the queens we've already placed until our current position
        for (int i = 1; i <= slice.Length; i++)
        {
            int queenPosition = slice[currentRow - i];

            // Check if the preceeding queen is in the same row
            // Or if she's on a diagonal path from the position that we want to place on
            if (position == queenPosition
                || queenPosition == position - i
                || queenPosition == position + i)
            {
                return false;
            }
        }

        return true;
    }

    public List<int[]> Solve()
    {
        if (_solutions.Count == 0)
        {
            SolveRecursivly();
        }

        return _solutions;
    }

    private void SolveRecursivly(int row = 0)
    {
        // If we make it here, we've found a solution
        if (row == _numberOfQueens)
        {
            AddSolution();
            return;
        }

        // Try every possible solution for the current row
        for (int column = 0; column < _numberOfQueens; column++)
        {
            if (CanPlaceQueen(row, column))
            {
                _partialSolve[row] = column;
                SolveRecursivly(row + 1);
            }
        }
    }

    private void AddSolution()
    {
        var copy = new int[_numberOfQueens];
        _partialSolve.CopyTo(copy, 0);
        _solutions.Add(copy);
    }
}
