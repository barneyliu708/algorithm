using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC155MinStack
    {
        public class MinStack
        {
            private Stack<int[]> stack;

            public MinStack()
            {
                this.stack = new Stack<int[]>();
            }

            public void Push(int val)
            {

                if (this.stack.Count == 0)
                {
                    this.stack.Push(new int[] { val, val });
                    return;
                }

                int curMin = this.stack.Peek()[1];
                this.stack.Push(new int[] { val, Math.Min(val, curMin) });
            }

            public void Pop()
            {
                this.stack.Pop();
            }

            public int Top()
            {
                return this.stack.Peek()[0];
            }

            public int GetMin()
            {
                return this.stack.Peek()[1];
            }
        }

        public class TwoStackApproach
        {
            public class MinStack
            {

                private Stack<int> stack;
                private Stack<int> minStack;

                public MinStack()
                {
                    stack = new Stack<int>();
                    minStack = new Stack<int>();
                }

                public void Push(int val)
                {
                    stack.Push(val);
                    if (minStack.Count == 0)
                    {
                        minStack.Push(val);
                    }
                    else
                    {
                        minStack.Push(Math.Min(minStack.Peek(), val));
                    }
                }

                public void Pop()
                {
                    stack.Pop();
                    minStack.Pop();
                }

                public int Top()
                {
                    return stack.Peek();
                }

                public int GetMin()
                {
                    return minStack.Peek();
                }
            }
        }
    }
}
