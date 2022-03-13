using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1376TimeNeededToInformAllEmployees
    {
        private int maxTime = 0;

        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, List<int>> subordinates = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                int m = manager[i];
                if (!subordinates.ContainsKey(m))
                {
                    subordinates[m] = new List<int>();
                }
                subordinates[m].Add(i);
            }

            Dft(subordinates, headID, informTime, 0);

            return maxTime;
        }

        private void Dft(Dictionary<int, List<int>> subordinates, int manager, int[] informTime, int curTime)
        {

            if (!subordinates.ContainsKey(manager))
            {
                maxTime = Math.Max(maxTime, curTime);
                return;
            }

            curTime += informTime[manager];
            foreach (int employee in subordinates[manager])
            {
                Dft(subordinates, employee, informTime, curTime);
            }
        }
    }
}
