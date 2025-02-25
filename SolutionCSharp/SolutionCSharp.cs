﻿using System;
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

        //problem 178 : leetCode 441. Arranging Coins
        public int ArrangeCoins(int n)
        {
            long left = 0, right = n / 2 + 1;
            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long sum = mid * (mid + 1) / 2;
                if (sum == n)
                    return (int)mid;
                if (sum < n)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return (int)right;
        }
    }
}
