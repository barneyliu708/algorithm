using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC138CopyListWithRandomPointer
    {

        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node CopyRandomList(Node head)
        {
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
            return CopyRandomList(head, visited);
        }

        private Node CopyRandomList(Node head, Dictionary<Node, Node> visited)
        {
            if (head == null)
            {
                return head;
            }

            if (visited.ContainsKey(head))
            {
                return visited[head];
            }

            Node clone = new Node(head.val);
            visited[head] = clone;

            clone.next = CopyRandomList(head.next, visited);
            clone.random = CopyRandomList(head.random, visited);

            return clone;
        }
    }
}
