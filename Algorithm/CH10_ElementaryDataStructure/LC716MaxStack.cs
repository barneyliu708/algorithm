using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC716MaxStack
    {
        public class TwoStackApproach
        {
            public class MaxStack
            {
                private Stack<int> stack;
                private Stack<int> maxstack;

                public MaxStack()
                {
                    stack = new Stack<int>();
                    maxstack = new Stack<int>();
                }

                public void Push(int x)
                {
                    stack.Push(x);
                    maxstack.Push(maxstack.Count == 0 ? x : Math.Max(maxstack.Peek(), x));
                }

                public int Pop()
                {
                    maxstack.Pop();
                    return stack.Pop();
                }

                public int Top()
                {
                    return stack.Peek();
                }

                public int PeekMax()
                {
                    return maxstack.Peek();
                }

                public int PopMax()
                {
                    int max = PeekMax();
                    Stack<int> temp = new Stack<int>();
                    while (stack.Peek() < max)
                    {
                        temp.Push(Pop());
                    }
                    Pop();
                    while (temp.Count > 0)
                    {
                        Push(temp.Pop());
                    }

                    return max;
                }
            }
        }

        public class SecondDone
        {
            public class MaxStack
            {

                private Stack<int> stack;
                private Stack<int> max;

                public MaxStack()
                {
                    stack = new Stack<int>();
                    max = new Stack<int>();
                }

                public void Push(int x)
                {
                    stack.Push(x);
                    if (max.Count == 0)
                    {
                        max.Push(x);
                    }
                    else
                    {
                        max.Push(Math.Max(max.Peek(), x));
                    }
                }

                public int Pop()
                {
                    max.Pop();
                    return stack.Pop();
                }

                public int Top()
                {
                    return stack.Peek();
                }

                public int PeekMax()
                {
                    return max.Peek();
                }

                public int PopMax() // always reuse exiting functions to simplify the logic
                {
                    Stack<int> temp = new Stack<int>();
                    while (PeekMax() > Top())
                    {
                        temp.Push(Pop());
                    }
                    int ans = Pop();
                    while (temp.Count > 0)
                    {
                        Push(temp.Pop());
                    }
                    return ans;
                }
            }
        }
    }
}
