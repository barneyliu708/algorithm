using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure.Ch10_1_StacksAndQueues
{
    [TestFixture]
    public class Exercises
    {
        [Test]
        public void Exercise_10_1()
        {
            Stack stack = new Stack(20);
            stack.Push(4);
            stack.Push(1);
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop());
            stack.Push(8);
            Assert.AreEqual(8, stack.Pop());
        }

        [Test]
        public void Exercise_10_3()
        {
            Queue queue = new Queue(20);
            queue.Enqueue(4);
            queue.Enqueue(1);
            queue.Enqueue(3);
            Assert.AreEqual(4, queue.Dequeue());
            queue.Enqueue(8);
            Assert.AreEqual(1, queue.Dequeue());
        }
    }
}
