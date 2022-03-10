using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1485CloneBinaryTreeWithRandomPointer
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node random;
            public Node(int val = 0, Node left = null, Node right = null, Node random = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.random = random;
            }
        }

        public class NodeCopy 
        {
            public int val;
            public NodeCopy left;
            public NodeCopy right;
            public NodeCopy random;
            public NodeCopy(int val = 0, NodeCopy left = null, NodeCopy right = null, NodeCopy random = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.random = random;
            }
        }

        public NodeCopy CopyRandomBinaryTree(Node root)
        {

            Dictionary<Node, NodeCopy> map = new Dictionary<Node, NodeCopy>();

            NodeCopy rootcp = DftCopyValue(root, map);

            DftCopyPointer(root, rootcp, map);

            return rootcp;
        }

        private NodeCopy DftCopyValue(Node root, Dictionary<Node, NodeCopy> map)
        {
            if (root == null)
            {
                return null;
            }

            NodeCopy rootcp = new NodeCopy(root.val);
            map[root] = rootcp; // map from original node to copy node

            rootcp.left = DftCopyValue(root.left, map);
            rootcp.right = DftCopyValue(root.right, map);

            return rootcp;
        }

        private void DftCopyPointer(Node root, NodeCopy rootcp, Dictionary<Node, NodeCopy> map)
        {
            if (root == null || rootcp == null)
            {
                return;
            }

            if (root.random != null)
            {
                rootcp.random = map[root.random];
            }

            DftCopyPointer(root.left, rootcp.left, map);
            DftCopyPointer(root.right, rootcp.right, map);
        }
    }
}
