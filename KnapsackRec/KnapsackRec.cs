using System;

namespace KnapsackRec
{
    internal class KnapsackRec
    {
        private int[] _sizes;
        private int[] _values;

        public int Solve(int capacity, int[] sizes, int[] values)
        {
            _sizes = sizes;
            _values = values;

            return Compute(capacity);
        }

        private int Compute(int capacity)
        {
            if (capacity == 0)
                return 0;

            int maxVal = int.MinValue;

            for (int i = 0; i < _sizes.Length; i++)
            {
                if (capacity < _sizes[i]) continue;

                maxVal = Math.Max(maxVal, Compute(capacity - _sizes[i]) + _values[i]);
            }

            return maxVal;
        }
    }
}