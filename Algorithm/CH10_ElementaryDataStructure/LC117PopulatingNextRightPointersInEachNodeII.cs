using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC117PopulatingNextRightPointersInEachNodeII
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        public Node Connect(Node root)
        {

            if (root == null)
            {
                return root;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {

                int count = queue.Count;

                for (int i = 0; i < count; i++)
                {

                    Node curNode = queue.Dequeue();

                    if (i < count - 1)
                    { // if curNode is not the rightmost node in current level.
                        curNode.next = queue.Peek();
                    }

                    if (curNode.left != null)
                    {
                        queue.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        queue.Enqueue(curNode.right);
                    }
                }
            }

            return root;
        }
    }
}
