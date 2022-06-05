using System.Text.Json;

namespace NQueensProblem.UnitTests.Data;

public static class NQueensSolutions
{
    public static List<int[]> Get(int n)
    {
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), "Data", $"{n}-queens-solutions.json");

        if (!File.Exists(fileName))
        {
            throw new ArgumentException($"Solutions definitions does not exist for n = {n}", nameof(n));
        }

        using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        var result = JsonSerializer.Deserialize<List<int[]>>(stream);

        if (result is null)
        {
            throw new Exception($"Unable to deserialize solution file for n = {n}.");
        }

        return result;
    }
}
