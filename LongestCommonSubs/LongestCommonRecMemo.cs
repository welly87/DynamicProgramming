using System;

namespace LongestCommonSubs
{
    class LongestCommonRecMemo
    {
        private string _first;
        private string _second;

        private string[,] _memo;
        //private int _count = 0;
        private string MLCS(int firstIdx, int secondIdx)
        {
            if (firstIdx >= _first.Length || secondIdx >= _second.Length)
                return "";

            if (_memo[firstIdx, secondIdx] != null)
                return _memo[firstIdx, secondIdx];
            else
                return _memo[firstIdx, secondIdx] = LCS(firstIdx, secondIdx);
        }

        private string LCS(int firstIdx, int secondIdx)
        {
            //Console.WriteLine("{0} {1}", firstIdx, secondIdx);
            //_count++;
            //var first = _first.Substring(firstIdx);
            //var second = _second.Substring(secondIdx);

            //if (first == string.Empty || second == string.Empty)
            //    return "";

            if (firstIdx == _first.Length || secondIdx == _second.Length)
                return "";

            if (_first[firstIdx] == _second[secondIdx])
                return _first[firstIdx] + MLCS(firstIdx + 1, secondIdx + 1);
            else
            {
                var resultFirst = MLCS(firstIdx + 1, secondIdx);
                var resultSecond = MLCS(firstIdx, secondIdx + 1);

                if (resultFirst.Length > resultSecond.Length)
                    _memo[firstIdx, secondIdx] = resultFirst;
                else
                    _memo[firstIdx, secondIdx] = resultSecond;

                return _memo[firstIdx, secondIdx];
            }
        }

        public string Solve(string first, string second)
        {
            _first = first;
            _second = second;
            //int maxLength = Math.Max(first.Length, second.Length);
            _memo = new String[first.Length, second.Length];

            _memo[0, 0] = "";

            var result = LCS(0, 0);

            //Console.WriteLine(_count);

            return result;
        }
    }
}
