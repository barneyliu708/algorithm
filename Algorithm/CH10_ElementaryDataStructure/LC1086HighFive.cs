using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1086HighFive
    {
        public int[][] HighFive(int[][] items)
        {
            int TOP = 5;

            Dictionary<int, PriorityQueue<int, int>> map = new Dictionary<int, PriorityQueue<int, int>>();
            foreach (int[] item in items)
            {
                int ID = item[0];
                int score = item[1];
                if (!map.ContainsKey(ID))
                {
                    map[ID] = new PriorityQueue<int, int>();
                }
                map[ID].Enqueue(score, score);
                if (map[ID].Count > TOP)
                {
                    map[ID].Dequeue();
                }
            }

            List<int[]> ans = new List<int[]>();
            int[] IDs = map.Keys.ToArray();
            Array.Sort(IDs);
            foreach (int ID in IDs)
            {
                int sum = 0;
                PriorityQueue<int, int> scores = map[ID];
                while (scores.Count > 0)
                {
                    sum += scores.Dequeue();
                }
                ans.Add(new int[] { ID, sum / TOP });
            }

            return ans.ToArray();
        }
    }
}
