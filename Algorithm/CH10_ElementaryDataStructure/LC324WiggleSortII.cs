using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC324WiggleSortII
    {
        public void WiggleSort(int[] nums)
        {
            int[] temp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                temp[i] = nums[i];
            }
            Array.Sort(temp);

            int s = (nums.Length - 1) / 2;
            int b = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i % 2 == 1 ? temp[b--] : temp[s--];
            }
        }
    }
}
