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

        //problem 180 : leetCode 414. Third Maximum Number
        public int ThirdMax(int[] nums)
        {
            SortedSet<int> st = new SortedSet<int>(nums, Comparer<int>.Create((a, b) => b.CompareTo(a)));
            if (st.Count >= 3)
            {
                return st.ElementAt(2);
            }
            return st.ElementAt(0);
        }

        //problem 181 : leetCode 2570. Merge Two 2D Arrays by Summing Values
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            int i = 0, j = 0;
            List<int[]> merge = new List<int[]>();

            while (i < nums1.Length || j < nums2.Length)
            {
                int[] both = new int[2];

                if (i >= nums1.Length)
                {
                    both[0] = nums2[j][0];
                    both[1] = nums2[j][1];
                    j++;
                }
                else if (j >= nums2.Length)
                {
                    both[0] = nums1[i][0];
                    both[1] = nums1[i][1];
                    i++;
                }
                else
                {
                    if (nums1[i][0] < nums2[j][0])
                    {
                        both[0] = nums1[i][0];
                        both[1] = nums1[i][1];
                        i++;
                    }
                    else if (nums1[i][0] > nums2[j][0])
                    {
                        both[0] = nums2[j][0];
                        both[1] = nums2[j][1];
                        j++;
                    }
                    else
                    {
                        both[0] = nums1[i][0];
                        both[1] = nums1[i][1] + nums2[j][1];
                        i++;
                        j++;
                    }
                }
                merge.Add(both);
            }

            return merge.ToArray();
        }

        //problem 182 : leetCode 3467. Transform Array by Parity  
        public int[] TransformArray(int[] nums)
        {
            int[] ans = new int[nums.Length];
            int i = 0;
            int j = nums.Length - 1;
            foreach (int val in nums)
            {
                if (val % 2 == 0)
                {
                    ans[i] = 0;
                    i++;
                }
                else
                {
                    ans[j] = 1;
                    j--;
                }
            }
            return ans;
        }

        //problem 183 : leetCode 3190. Find Minimum Operations to Make All Elements Divisible by Three
        public int MinimumOperations(int[] nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 3 != 0)
                    ans++;
            }
            return ans;
        }






    }
}
