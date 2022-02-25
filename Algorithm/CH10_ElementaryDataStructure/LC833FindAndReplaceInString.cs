using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC833FindAndReplaceInString
    {
        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            KeyValuePair<int, int>[] sortedIndices = new KeyValuePair<int, int>[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                sortedIndices[i] = new KeyValuePair<int, int>(indices[i], i);
            }
            Array.Sort(sortedIndices, (KeyValuePair<int, int> x, KeyValuePair<int, int> y) => {
                return y.Key.CompareTo(x.Key); // decending order
            });

            for (int i = 0; i < indices.Length; i++)
            {
                int id = sortedIndices[i].Value;
                int indice = sortedIndices[i].Key;
                string source = sources[id];
                string target = targets[id];
                if (s.Substring(indice, source.Length) == source)
                {
                    s = s.Substring(0, indice) + target + s.Substring(indice + source.Length);
                }
            }

            return s;
        }
    }
}
