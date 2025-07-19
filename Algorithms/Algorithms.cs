using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            return n switch
            {
                < 0 => throw new ArgumentOutOfRangeException(nameof(n), "Factorial cannot be calculated for negative numbers"),
                <= 1 => 1,
                _ => Enumerable.Range(1, n).Aggregate(1, (acc, i) => acc * i)
            };
        }

        public static string FormatSeparators(params string[] items)
        {
            return items switch
            {
                null or [] => "",
                [var single] => single,
                [var first, var second] => $"{first} and {second}",
                [.. var head, var tail] => $"{string.Join(", ", head)} and {tail}"
            };
        }
    }
}