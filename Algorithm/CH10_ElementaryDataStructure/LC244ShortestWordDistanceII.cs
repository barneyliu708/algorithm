using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC244ShortestWordDistanceII
    {
        public class WordDistance
        {

            private Dictionary<string, List<int>> map;

            public WordDistance(string[] wordsDict)
            {
                map = new Dictionary<string, List<int>>();
                for (int i = 0; i < wordsDict.Length; i++)
                {
                    if (!map.ContainsKey(wordsDict[i]))
                    {
                        map[wordsDict[i]] = new List<int>();
                    }
                    map[wordsDict[i]].Add(i);
                }
            }

            public int Shortest(string word1, string word2)
            {
                List<int> word1Positions = map[word1];
                List<int> word2Positions = map[word2];
                word1Positions.Sort();
                word2Positions.Sort();

                int l = 0;
                int r = 0;
                int ans = int.MaxValue;
                while (l < word1Positions.Count && r < word2Positions.Count)
                {
                    ans = Math.Min(ans, Math.Abs(word1Positions[l] - word2Positions[r]));
                    if (word1Positions[l] < word2Positions[r])
                    {
                        l++;
                    }
                    else
                    {
                        r++;
                    }
                }

                return ans;
            }
        }

    }
}
