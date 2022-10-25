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

        public class SecondDone
        {
            public class RandomizedSet
            {

                private List<int> list;
                private Dictionary<int, int> map; // val - index of val in the list
                private Random rand;

                public RandomizedSet()
                {
                    list = new List<int>();
                    map = new Dictionary<int, int>();
                    rand = new Random();
                }

                public bool Insert(int val)
                {
                    if (map.ContainsKey(val))
                    {
                        return false;
                    }
                    list.Add(val); // O(1);
                    map[val] = list.Count - 1; // O(1)

                    return true;
                }

                public bool Remove(int val)
                {
                    if (!map.ContainsKey(val))
                    {
                        return false;
                    }

                    // swap the val with the last element in the list
                    int ival = map[val];
                    int lastVal = list[list.Count - 1];
                    list[ival] = lastVal;
                    list[list.Count - 1] = val;
                    map[lastVal] = ival;

                    // remove the last element in the list
                    list.RemoveAt(list.Count - 1);
                    map.Remove(val);

                    return true;
                }

                public int GetRandom()
                {
                    return list[rand.Next(list.Count)];
                }
            }

        }

        public class ThirdDone
        {
            public class RandomizedSet
            {

                private Random rand;
                private Dictionary<int, int> map; // val - index
                private List<int> list;

                public RandomizedSet()
                {
                    rand = new Random();
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
                    int val_index = map[val];
                    Swap(val_index, list.Count - 1);
                    map[list[val_index]] = val_index;
                    map.Remove(val);
                    list.RemoveAt(list.Count - 1);
                    return true;
                }

                public int GetRandom()
                {
                    int rand_index = rand.Next(list.Count);
                    return list[rand_index];
                }

                private void Swap(int i, int j)
                {
                    int temp = this.list[i];
                    this.list[i] = this.list[j];
                    this.list[j] = temp;
                }
            }
        }
    }
}
