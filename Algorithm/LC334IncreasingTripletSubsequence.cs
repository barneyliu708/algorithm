using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class LC334IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {

            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int num in nums)
            {
                if (num <= first)
                {
                    first = num;
                }
                else if (num <= second)
                {
                    second = num;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}
