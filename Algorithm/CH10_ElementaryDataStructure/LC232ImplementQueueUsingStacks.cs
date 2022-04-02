using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC232ImplementQueueUsingStacks
    {
        public class MyQueue
        {

            private Stack<int> stack1;
            private Stack<int> stack2;
            private int front;

            public MyQueue()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            public void Push(int x)
            {
                if (stack1.Count == 0)
                {
                    front = x;
                }
                stack1.Push(x);
            }

            public int Pop()
            {
                if (stack2.Count == 0)
                {
                    while (stack1.Count != 0)
                    {
                        stack2.Push(stack1.Pop());
                    }
                }
                return stack2.Pop();
            }

            public int Peek()
            {
                if (stack2.Count != 0)
                {
                    return stack2.Peek();
                }
                return front;
            }

            public bool Empty()
            {
                return stack1.Count == 0 && stack2.Count == 0;
            }
        }

        public class SecondDone
        {
            public class MyQueue
            {

                private Stack<int> inStack;
                private Stack<int> outStack;

                public MyQueue()
                {
                    inStack = new Stack<int>();
                    outStack = new Stack<int>();
                }

                public void Push(int x)
                {
                    inStack.Push(x);
                }

                public int Pop()
                {
                    if (outStack.Count == 0)
                    {
                        while (inStack.Count > 0)
                        {
                            outStack.Push(inStack.Pop());
                        }
                    }
                    return outStack.Pop();
                }

                public int Peek()
                {
                    if (outStack.Count == 0)
                    {
                        while (inStack.Count > 0)
                        {
                            outStack.Push(inStack.Pop());
                        }
                    }
                    return outStack.Peek();
                }

                public bool Empty()
                {
                    return inStack.Count == 0 && outStack.Count == 0;
                }
            }
        }
    }
}
