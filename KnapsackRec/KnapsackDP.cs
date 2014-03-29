using System;

namespace KnapsackRec
{
    internal class KnapsackDP
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

            for (int i = 1; i <= capacity; i++)
            {
                for (int j = 0; j < sizes.Length; j++)
                {
                    if (i < _sizes[j]) continue;

                    _memo[i] = Math.Max(_memo[i], _memo[i - _sizes[j]] + values[j]);
                }
            }

            return _memo[capacity];
        }
    }
}