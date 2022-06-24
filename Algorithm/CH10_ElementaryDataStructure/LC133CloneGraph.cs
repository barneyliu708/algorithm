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

        public class BFTApproach
        {
            public Node CloneGraph(Node node)
            {
                if (node == null)
                {
                    return null;
                }

                Dictionary<Node, Node> map = new Dictionary<Node, Node>();

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(node);
                map[node] = new Node(node.val, new List<Node>());
                while (queue.Count > 0)
                {
                    Node curNode = queue.Dequeue();
                    foreach (Node neighbor in curNode.neighbors)
                    {
                        if (!map.ContainsKey(neighbor))
                        {
                            map[neighbor] = new Node(neighbor.val, new List<Node>());
                            queue.Enqueue(neighbor);
                        }
                        map[curNode].neighbors.Add(map[neighbor]);
                    }
                }

                return map[node];
            }
        }
    }

    public class ThirdDone
    {
        public Node CloneGraph(Node node)
        {
            return CloneGraphUti(node, new Dictionary<Node, Node>());
        }

        private Node CloneGraphUti(Node node, Dictionary<Node, Node> map)
        {
            if (node == null)
            {
                return null;
            }
            if (map.ContainsKey(node))
            {
                return map[node];
            }
            Node cloneNode = new Node(node.val, new List<Node>());
            map[node] = cloneNode;
            foreach (Node neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraphUti(neighbor, map));
            }

            return cloneNode;
        }
    }
}
