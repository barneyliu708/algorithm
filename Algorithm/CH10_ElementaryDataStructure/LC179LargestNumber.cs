using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC179LargestNumber
    {
        public string LargestNumber(int[] nums)
        {
            List<int> sortedNums = nums.ToList();
            sortedNums.Sort((x, y) => {
                string xs = x.ToString();
                string ys = y.ToString();
                return -1 * (xs + ys).CompareTo(ys + xs);
            });

            if (sortedNums[0] == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sortedNums.Count; i++)
            {
                sb.Append(sortedNums[i].ToString());
            }
            return sb.ToString();
        }
    }
}
