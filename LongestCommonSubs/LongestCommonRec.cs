using System;

namespace LongestCommonSubs
{
    internal class LongestCommonRec
    {
        private string _first;
        private string _second;

        private string LCS(int firstIdx, int secondIdx)
        {
            Console.WriteLine("{0} {1}", firstIdx, secondIdx);

            var first = _first.Substring(firstIdx);
            var second = _second.Substring(secondIdx);

            if (first == string.Empty || second == string.Empty)
                return "";

            if (first[0] == second[0])
                return first[0] + LCS(firstIdx + 1, secondIdx + 1);
            else
            {
                var resultFirst = LCS(firstIdx + 1, secondIdx);
                var resultSecond = LCS(firstIdx, secondIdx + 1);

                if (resultFirst.Length > resultSecond.Length)
                    return resultFirst;
                else
                    return resultSecond;
            }
        }

        public string Solve(string first, string second)
        {
            _first = first;
            _second = second;

            return LCS(0, 0);
        }
    }
}