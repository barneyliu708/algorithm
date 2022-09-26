using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    internal class LC1004MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            int l = 0;
            int r = 0;
            int ans = 0;
            while (r < nums.Length)
            {
                if (nums[r] == 0)
                {
                    k--;
                }

                while (k < 0)
                {
                    if (nums[l] == 0)
                    {
                        k++;
                    }
                    l++;
                }

                ans = Math.Max(ans, r - l + 1);

                r++;
            }
            return ans;
        }

        public class OptimizedApproach2
        {
            public int LongestOnes(int[] nums, int k)
            {
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < nums.Length)
                {
                    if (nums[r] == 0)
                    {
                        k--;
                    }

                    if (k < 0)
                    {
                        if (nums[l] == 0)
                        {
                            k++;
                        }
                        l++;
                    }

                    r++;
                }
                return r - l;
            }
        }

        public class ThirdDone
        {
            private int ans = 0;

            public int LongestOnes(int[] nums, int k)
            {
                LongestUti(nums, k, 0, 0);
                return ans;
            }

            private void LongestUti(int[] nums, int k, int istart, int curCnt)
            {
                ans = Math.Max(curCnt, ans);
                if (istart >= nums.Length)
                {
                    return;
                }
                for (int i = istart; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                    {
                        curCnt++;
                    }
                    else
                    {
                        if (k > 0)
                        {
                            LongestUti(nums, k - 1, i + 1, curCnt + 1);
                        }
                        LongestUti(nums, k, i + 1, 0);
                    }
                }
            }
        }

        public class ForthDone
        {
            public int LongestOnes(int[] nums, int k)
            {
                int kcount = 0;
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < nums.Length)
                {
                    if (nums[r] == 0)
                    {
                        kcount++;
                    }
                    while (kcount > k)
                    {
                        if (nums[l] == 0)
                        {
                            kcount--;
                        }
                        l++;
                    }

                    ans = Math.Max(ans, r - l + 1);
                    r++;
                }
                return ans;
            }
        }

        [TestCase]
        public void TestCase1()
        {
            int[] nums = new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            int k = 2;
            ThirdDone solution = new ThirdDone();
            int result = solution.LongestOnes(nums, k);
        }
    }
}
