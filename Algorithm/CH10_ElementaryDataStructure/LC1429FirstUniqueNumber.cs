using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    internal class LC1429FirstUniqueNumber
    {
        public class FirstUnique
        {

            private HashSet<int> uniques;
            private HashSet<int> duplicates;
            private int firstIndex;
            private IList<int> list;

            public FirstUnique(int[] nums)
            {
                uniques = new HashSet<int>();
                duplicates = new HashSet<int>();
                this.list = new List<int>();
                firstIndex = 0;


                foreach (int num in nums)
                {
                    this.list.Add(num);
                    if (duplicates.Contains(num))
                    {
                        continue;
                    }
                    if (!uniques.Contains(num))
                    {
                        uniques.Add(num);
                    }
                    else
                    {
                        duplicates.Add(num);
                        uniques.Remove(num);
                    }
                }
            }

            public int ShowFirstUnique()
            {
                while (firstIndex < list.Count && !uniques.Contains(list[firstIndex]))
                {
                    firstIndex++;
                }

                if (firstIndex < list.Count)
                {
                    return list[firstIndex];
                }

                return -1;
            }

            public void Add(int value)
            {
                list.Add(value);
                if (duplicates.Contains(value))
                {
                    return;
                }
                if (!uniques.Contains(value))
                {
                    uniques.Add(value);
                }
                else
                {
                    duplicates.Add(value);
                    uniques.Remove(value);
                }
            }
        }

        public class SecondDone
        {
            public class FirstUnique
            {

                private Dictionary<int, int> duplicate;
                private Queue<int> queue;
                public FirstUnique(int[] nums)
                {
                    queue = new Queue<int>();
                    duplicate = new Dictionary<int, int>();
                    foreach (int num in nums)
                    {
                        queue.Enqueue(num);
                        if (!duplicate.ContainsKey(num))
                        {
                            duplicate[num] = 0;
                        }
                        duplicate[num]++;
                    }
                }

                public int ShowFirstUnique()
                {
                    while (queue.Count > 0 && duplicate[queue.Peek()] > 1)
                    {
                        queue.Dequeue();
                    }
                    return queue.Count > 0 ? queue.Peek() : -1;
                }

                public void Add(int val)
                {
                    queue.Enqueue(val);
                    if (!duplicate.ContainsKey(val))
                    {
                        duplicate[val] = 0;
                    }
                    duplicate[val]++;
                }
            }
        }

        public class ThirdDone
        {
            public class FirstUnique
            {

                private Queue<int> queue;
                private Dictionary<int, int> count; // num - count

                public FirstUnique(int[] nums)
                {
                    queue = new Queue<int>();
                    count = new Dictionary<int, int>();
                    foreach (int num in nums)
                    {
                        this.Add(num);
                    }
                }

                public int ShowFirstUnique()
                {
                    while (queue.Count > 0 && count[queue.Peek()] > 1)
                    {
                        queue.Dequeue();
                    }
                    return queue.Count > 0 ? queue.Peek() : -1;
                }

                public void Add(int value)
                {
                    if (!count.ContainsKey(value))
                    {
                        count[value] = 0;
                    }
                    count[value]++;
                    if (count[value] == 1)
                    {
                        queue.Enqueue(value);
                    }
                }
            }
        }

        [Test]
        public void TestCase1()
        {
            var obj = new FirstUnique(new[] { 7, 7, 7, 7, 7, 7 });
            Assert.AreEqual(-1, obj.ShowFirstUnique());
            obj.Add(7);
            obj.Add(3);
            obj.Add(3);
            obj.Add(7);
            obj.Add(17);
            Assert.AreEqual(17, obj.ShowFirstUnique());
        }
    }
}
