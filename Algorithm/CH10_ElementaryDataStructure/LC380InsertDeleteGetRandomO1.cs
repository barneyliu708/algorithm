using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC380InsertDeleteGetRandomO1
    {
        public class RandomizedSet
        {

            private Dictionary<int, int> map; // val - index of val in the list
            private List<int> list;
            private Random rand = new Random();

            public RandomizedSet()
            {
                map = new Dictionary<int, int>();
                list = new List<int>();
            }

            public bool Insert(int val)
            {
                if (map.ContainsKey(val))
                {
                    return false;
                }

                list.Add(val);
                map[val] = list.Count - 1;

                return true;
            }

            public bool Remove(int val)
            {
                if (!map.ContainsKey(val))
                {
                    return false;
                }

                // move the last element to the index of val
                int lastElement = list[list.Count - 1];
                int valIndex = map[val];
                list[valIndex] = lastElement;
                map[lastElement] = valIndex;

                // remove val
                list.RemoveAt(list.Count - 1);
                map.Remove(val);

                return true;
            }

            public int GetRandom()
            {

                return list[rand.Next(list.Count)]; // return random element between 0 and list.count - 1
            }
        }
    }
}
