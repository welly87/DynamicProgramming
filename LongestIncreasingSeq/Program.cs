using System;

namespace LongestIncreasingSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] num = { 5, 3, 4, 8, 6, 7 };
            int[] num = { -7, 10, 9, 2, 3, 8, 8, 1 };

            var lis = new LongestIncreasingDP();
            Console.WriteLine(lis.Solve(num));
        }
    }

    internal class LongestIncreasingDP
    {
        public int Solve(int[] num)
        {
            var maxInc = new int[num.Length];

            for (int i = 0; i < maxInc.Length; i++)
            {
                maxInc[i] = int.MinValue;
            }

            maxInc[0] = 1;
            int maxsofar = 1;

            for (int i = 1; i < maxInc.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (num[i] > num[j])
                    {
                        maxInc[i] = Math.Max(maxInc[i], maxInc[j] + 1);

                        maxsofar = Math.Max(maxInc[i], maxsofar);
                    }
                }
            }

            return maxsofar;
        }
    }
}
