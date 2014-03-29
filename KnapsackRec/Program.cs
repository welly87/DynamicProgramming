using System;

namespace KnapsackRec
{
    class Program
    {
        static void Main(string[] args)
        {
            var knapsack = new KnapsackDP();
            var capacity = 17;
            var sizes = new int[] {3, 4, 7, 8, 9};
            var values = new int[] {4, 5, 10, 11, 13};
            Console.WriteLine(knapsack.Solve(capacity, sizes, values));

        }
    }
}
