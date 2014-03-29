using System;

namespace KnapsackRec
{
    internal class KnapsackRecMemo
    {
        private int[] _sizes;
        private int[] _values;

        private int[] _memo;

        public int Solve(int capacity, int[] sizes, int[] values)
        {
            _sizes = sizes;
            _values = values;

            _memo = new int[capacity + 1];

            for (int i = 0; i < _memo.Length; i++)
            {
                _memo[i] = int.MinValue;
            }

            _memo[0] = 0;

            return Compute(capacity);
        }

        private int Compute(int capacity)
        {
            if (_memo[capacity] != int.MinValue)
                return _memo[capacity];

            //if (capacity == 0)
            //    return 0;

            //int maxVal = int.MinValue;

            for (int i = 0; i < _sizes.Length; i++)
            {
                if (capacity < _sizes[i]) continue;

                _memo[capacity] = Math.Max(_memo[capacity], Compute(capacity - _sizes[i]) + _values[i]);
            }

            return _memo[capacity];
        }
    }
}