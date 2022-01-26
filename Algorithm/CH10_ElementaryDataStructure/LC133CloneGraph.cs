using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    class LC133CloneGraph
    {
        public Node CloneGraph(Node node)
        {
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
            return CloneGraph(node, visited);
        }

        private Node CloneGraph(Node node, Dictionary<Node, Node> visited)
        {

            if (node == null)
            {
                return node;
            }

            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            Node cloneNode = new Node(node.val);
            visited[node] = cloneNode;

            foreach (Node neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph(neighbor, visited));
            }

            return cloneNode;
        }
    }
}
