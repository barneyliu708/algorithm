using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    class LC016_3SumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int diff = int.MaxValue;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length && diff != 0; i++)
            {
                int lo = i + 1;
                int ho = nums.Length - 1;
                while (lo < ho)
                {
                    int sum = nums[i] + nums[lo] + nums[ho];
                    if (Math.Abs(target - sum) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }
                    if (sum < target)
                    {
                        lo++;
                    }
                    else
                    {
                        ho--;
                    }
                }
            }

            return target - diff;
        }

        public class SecondDone
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                Array.Sort(nums);
                int diff = int.MaxValue;
                int ans = int.MaxValue;
                for (int i = 0; i < nums.Length; i++)
                {
                    int l = i + 1;
                    int r = nums.Length - 1;
                    while (l < r)
                    {
                        int sum = nums[i] + nums[l] + nums[r];
                        if (Math.Abs(target - sum) < diff)
                        {
                            ans = sum;
                            diff = Math.Abs(target - sum);
                        }
                        if (sum < target)
                        {
                            l++;
                        }
                        else if (sum > target)
                        {
                            r--;
                        }
                        else
                        { // sum == target, diff will be the 0
                            return target;
                        }
                    }
                }
                return ans;
            }
        }

        [Test]
        public void TestCase1()
        {
            int[] nums = new int[] { -1, 2, 1, -4 };
            int target = 1;

            int result = ThreeSumClosest(nums, target);
        }

        [Test]
        public void TestCase2()
        {
            int[] nums = new int[] { 0, 1, 2 };
            int target = 0;

            int result = ThreeSumClosest(nums, target);
        }

        [Test]
        public void TestCase3()
        {
            int[] nums = new int[] { 0, 2, 1, -3};
            int target = 1;

            int result = ThreeSumClosest(nums, target);
        }
    }
}
