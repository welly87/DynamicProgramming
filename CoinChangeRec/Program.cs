using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangeRec
{
    class Program
    {
        static void Main(string[] args)
        {
            CoinChange cchange = new CoinChange();
            cchange.Calculate();
        }
    }

    internal class CoinChange
    {
        private int[] coin = new[] {1, 3, 5};

        private int[] memo;

        private int sum = 11;

        public void Calculate()
        {
            memo = new int[11 + 1];

            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = int.MaxValue;
            }
            
            memo[0] = 0;

            Console.WriteLine(Change(11));
        }

        private int Change(int i)
        {
            //Console.WriteLine("Calculate : {0}", i);
            //if (i < 0)
            //    return int.MaxValue - 1;

            if (memo[i] != int.MaxValue) return memo[i];
            
            //if (i == 0)
            //    return 0;

            //int minVal = int.MaxValue;

            for (int j = 0; j < coin.Length; j++)
            {
                if (i - coin[j] < 0) continue;

                memo[i] = Math.Min(memo[i], Change(i - coin[j]) + 1);
            }

            //memo[i] = minVal;

            return memo[i];
        }
    }
}
