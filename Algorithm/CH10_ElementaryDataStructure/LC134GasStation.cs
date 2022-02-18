using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC134GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int totTank = 0;
            int curTank = 0;
            int startIndex = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                totTank += gas[i] - cost[i];
                curTank += gas[i] - cost[i];

                if (curTank < 0)
                {
                    startIndex = i + 1;
                    curTank = 0;
                }
            }

            return totTank >= 0 ? startIndex : -1;
        }
    }
}
