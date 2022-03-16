using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC346MovingAverageFromDataStream
    {
        public class MovingAverage
        {

            private Queue<int> queue;
            private int size;
            private int sum;

            public MovingAverage(int size)
            {
                this.size = size;
                queue = new Queue<int>();
            }

            public double Next(int val)
            {

                queue.Enqueue(val);
                sum += val;
                if (queue.Count > size)
                {
                    sum -= queue.Dequeue();
                }

                return (double)sum / queue.Count;
            }
        }
    }
}
