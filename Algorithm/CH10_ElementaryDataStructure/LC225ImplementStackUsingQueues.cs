using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC225ImplementStackUsingQueues
    {
        public class MyStack
        {

            private Queue<int> queue;

            public MyStack()
            {
                queue = new Queue<int>();
            }

            public void Push(int x)
            {
                queue.Enqueue(x);
                int count = queue.Count;
                while (count > 1)
                {
                    queue.Enqueue(queue.Dequeue());
                    count--;
                }
            }

            public int Pop()
            {
                return queue.Dequeue();
            }

            public int Top()
            {
                return queue.Peek();
            }

            public bool Empty()
            {
                return queue.Count == 0;
            }
        }
    }
}
