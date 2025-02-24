using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCSharp
{
    internal class SolutionCSharp
    {

        //problem 177 : leetCode 3146. Permutation Difference between Two Strings
        public int FindPermutationDifference(string s, string t)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int pos = t.IndexOf(s[i]);
                sum += Math.Abs(pos - i);
            }
            return sum;
        }

    }
}
