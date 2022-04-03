using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1209RemoveAllAdjacentDuplicatesInStringII
    {
        public string RemoveDuplicates(string s, int k)
        {
            // sb:    [a,b,b,b,c,d,d,e]
            // stack: [1,1,2,3,1,1,2,1]
            Stack<int> counts = new Stack<int>();
            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length; i++)
            {
                // update the counts
                if (i == 0 || sb[i] != sb[i - 1])
                {
                    counts.Push(1);
                }
                else
                {
                    counts.Push(counts.Peek() + 1);
                }

                if (counts.Peek() == k)
                { // trigger the k duplicate removal
                    sb.Remove(i - k + 1, k);
                    i = i - k;
                    while (counts.Count > i + 1)
                    { // i + 1 = current valid length after the removal 
                        counts.Pop();
                    }
                }
            }

            return sb.ToString();
        }

        public class SecondDone
        {
            public string RemoveDuplicates(string s, int k)
            {
                Stack<char> stack = new Stack<char>();
                Stack<int> count = new Stack<int>();
                foreach (char ch in s)
                {
                    if (stack.Count == 0 || ch != stack.Peek())
                    {
                        count.Push(1);
                    }
                    else
                    {
                        count.Push(count.Peek() + 1);
                    }
                    stack.Push(ch);

                    // remove the duplicate
                    if (count.Peek() >= k)
                    {
                        int steps = count.Peek();
                        while (steps > 0)
                        {
                            count.Pop();
                            stack.Pop();
                            steps--;
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (char ch in stack)
                {
                    sb.Insert(0, ch);
                }
                return sb.ToString();
            }
        }
    }
}
