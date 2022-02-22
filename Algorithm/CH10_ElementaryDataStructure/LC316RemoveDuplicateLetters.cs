using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC316RemoveDuplicateLetters
    {
        public string RemoveDuplicateLetters(string s)
        {

            Stack<char> stack = new Stack<char>();
            HashSet<char> seen = new HashSet<char>();
            Dictionary<char, int> lastOccurs = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                lastOccurs[s[i]] = i;
            }

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (!seen.Contains(ch))
                {
                    while (stack.Count > 0 && ch < stack.Peek() && lastOccurs[stack.Peek()] > i)
                    {
                        seen.Remove(stack.Pop());
                    }
                    seen.Add(ch);
                    stack.Push(ch);
                }
            }

            StringBuilder sb = new StringBuilder();

            while (stack.Count > 0)
            {
                sb.Insert(0, stack.Pop());
            }

            return sb.ToString();
        }
    }
}
