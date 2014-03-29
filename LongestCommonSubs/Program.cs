using System;

namespace LongestCommonSubs
{
    class Program
    {
        static void Main(string[] args)
        {
            var lcs = new LongestCommonRecMemo();
            //Console.WriteLine(lcs.Solve("AGGTAB", "GXTXAYB"));
            //Console.WriteLine(lcs.Solve("AGGTAB", "GXTXAYB").Length);
            Console.WriteLine(lcs.Solve("abcdgh", "aedfhr"));
            Console.WriteLine(lcs.Solve("abcdgh", "aedfhr").Length);
        }
    }
}
