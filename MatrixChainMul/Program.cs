using System;
using System.Text;

namespace MatrixChainMul
{
    class Program
    {
        static void Main(string[] args)
        {
            var mc = new MatrixChain();
            //var min = mc.Solve(new int[] { 10, 100, 5, 50 });
            //var min = mc.Solve(new int[] { 1, 5, 20, 1 });
            var min = mc.Solve(new int[] { 1, 5, 20, 1 });
            Console.WriteLine(min);
        }
    }

    internal class MatrixChain
    {
        private int[] _dim;
        private int[,] _memo;
        private int[,] _partition;
        private int _length;

        public int mcm(int i, int j)
        {
            if (i == j) return 0;

            int min = int.MaxValue;

            for (int k = i; k < j; k++)
            {
                int calc = mcm_memo(i, k) + mcm_memo(k + 1, j) + _dim[i - 1] * _dim[k] * _dim[j];

                if (calc < min)
                {
                    min = calc;
                    _partition[i, j] = k;
                }
            }

            return min;
        }

        private int mcm_memo(int i, int j)
        {
            if (_memo[i, j] == -1)
                _memo[i, j] = mcm(i, j);

            return _memo[i, j];
        }

        public int Solve(int[] dim)
        {
            _dim = dim;
            _length = dim.Length;
            _memo = new int[dim.Length, dim.Length];
            _partition = new int[dim.Length, dim.Length];
            Fill(_memo);

            var result = mcm(1, dim.Length - 1);

            Console.WriteLine(PrintMCM(1, _length - 1));

            return result;
        }

        private string PrintMCM(int i, int j)
        {
            if (i == j)
            {
                return "A" + i;
            }
            else
            {
                var builder = new StringBuilder();

                builder.Append("(");
                builder.Append(PrintMCM(i, _partition[i, j]));

                builder.Append(" x ");

                builder.Append(PrintMCM(_partition[i, j] + 1, j));

                builder.Append(")");

                return builder.ToString();
            }

        }

        private void Print(int[,] partition)
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _length; j++)
                {
                    Console.Write(partition[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void Fill(int[,] memo)
        {
            for (int i = 0; i < _length; i++)
                for (int j = 0; j < _length; j++)
                    memo[i, j] = -1;
        }
    }
}
