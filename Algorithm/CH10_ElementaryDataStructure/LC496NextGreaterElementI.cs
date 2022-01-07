using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC496NextGreaterElementI
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {

            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                while (stack.Count != 0 && stack.Peek() < nums2[i])
                {
                    map[stack.Pop()] = nums2[i];
                }
                stack.Push(nums2[i]);
            }

            while (stack.Count != 0)
            {
                map[stack.Pop()] = -1;
            }

            int[] ans = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                ans[i] = map[nums1[i]];
            }

            return ans;
        }

        [Test]
        public void TestCases()
        {
            int[] nums1 = new int[] { 4, 1, 2 };
            int[] nums2 = new int[] { 1, 3, 4, 2 };

            var testResult = NextGreaterElement(nums1, nums2);
        }
    }
}
