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

        //problem 179 : leetCode 5. Longest Palindromic Substring
        public string LongestPalindrome(string s)
        {
            SortedDictionary<int, string> subs = new SortedDictionary<int, string>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            int left, right;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (i + 1 < n && s[i] == s[i + 1])
                {
                    string str = s.Substring(i, 2);
                    left = i - 1;
                    right = i + 2;
                    while (left >= 0 && right < n && s[left] == s[right])
                    {
                        str = s[left] + str + s[right];
                        left--;
                        right++;
                    }
                    subs[str.Length] = str;
                }
                if (i + 2 < n && s[i] == s[i + 2])
                {
                    string str = s.Substring(i, 3);
                    left = i - 1;
                    right = i + 3;
                    while (left >= 0 && right < n && s[left] == s[right])
                    {
                        str = s[left] + str + s[right];
                        left--;
                        right++;
                    }
                    subs[str.Length] = str;
                }
            }
            if (subs.Count > 0)
            {
                return subs.First().Value;
            }
            return s.Length > 0 ? s[0].ToString() : "";
        }
    }
}
