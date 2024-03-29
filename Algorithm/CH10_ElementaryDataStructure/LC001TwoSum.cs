﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC001TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                map[nums[i]] = i;
            }

            return new int[2];
        }

        public class SecondDone
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int num = nums[i];
                    if (map.ContainsKey(target - num))
                    {
                        return new int[] { map[target - num], i };
                    }
                    map[num] = i;
                }

                return new int[] { -1, -1 };
            }
        }
    }
}
