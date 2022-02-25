using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC2034StockPriceFluctuation
    {
        public class StockPrice
        {

            Dictionary<int, int> timeToPrices;
            int latestTimestamp;

            PriorityQueue<(int price, int timestamp), int> maxpq;
            PriorityQueue<(int price, int timestamp), int> minpq;

            public StockPrice()
            {
                timeToPrices = new Dictionary<int, int>();
                latestTimestamp = 0;
                maxpq = new PriorityQueue<(int price, int timestamp), int>();
                minpq = new PriorityQueue<(int price, int timestamp), int>();
            }

            public void Update(int timestamp, int price)
            {
                latestTimestamp = Math.Max(latestTimestamp, timestamp);
                timeToPrices[timestamp] = price;

                maxpq.Enqueue((price, timestamp), -price);
                minpq.Enqueue((price, timestamp), price);
            }

            public int Current()
            {
                return timeToPrices[latestTimestamp];
            }

            public int Maximum()
            {
                while (maxpq.Count > 0)
                {
                    (int price, int timestamp) = maxpq.Peek();
                    if (timeToPrices[timestamp] != price)
                    {
                        maxpq.Dequeue();
                    }
                    else
                    {
                        return price;
                    }
                }
                return -1;
            }

            public int Minimum()
            {
                while (minpq.Count > 0)
                {
                    (int price, int timestamp) = minpq.Peek();
                    if (timeToPrices[timestamp] != price)
                    {
                        minpq.Dequeue();
                    }
                    else
                    {
                        return price;
                    }
                }
                return -1;
            }
        }

    }
}
