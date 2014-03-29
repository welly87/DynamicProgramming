using System;

namespace CoinChange
{
    class Program
    {

        private static void DP_Bottom_Up(int[] coin, int sum)
        {
            var coinsNum = new int[sum + 1];

            for (int i = 0; i < coinsNum.Length; i++)
            {
                coinsNum[i] = int.MaxValue;
            }

            coinsNum[0] = 0;

            for (int i = 1; i < coinsNum.Length; i++)
            {
                for (int j = 0; j < coin.Length; j++)
                {
                    if (coin[j] <= i)
                    {
                        coinsNum[i] = Math.Min(coinsNum[i], coinsNum[i - coin[j]] + 1);
                    }
                }
            }

            Console.WriteLine(coinsNum[sum]);
        }



        static void Main(string[] args)
        {
            var coin = new int[] {1, 3, 5};

            int sum = 11;

            //DP_Bottom_Up(coin, sum);


        }
    }
}
