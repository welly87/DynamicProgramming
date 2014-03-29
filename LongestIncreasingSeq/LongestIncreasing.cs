using System;

namespace LongestIncreasingSeq
{
    internal class LongestIncreasingRec
    {
        private int[] _nums;

        public int Solve(int[] num)
        {
            _nums = num;

            var max = 1;

            for (int i = 1; i < num.Length; i++)
            {
                max = Math.Max(max, LIS(i));
            }

            return max;
        }

        private int LIS(int i)
        {
            if (i == 0)
                return 1;
            
            int maxVal = 1;

            for (int j = 0; j < i; j++)
            {
                int currentEnd = _nums[i];
                int currentTry = _nums[j];

                if (currentEnd > currentTry)
                {
                    maxVal = Math.Max(maxVal, 1 + LIS(j));
                }
            }

            return maxVal;
        }
    }
}