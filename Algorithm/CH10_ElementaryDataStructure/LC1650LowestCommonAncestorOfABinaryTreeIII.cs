using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1650LowestCommonAncestorOfABinaryTreeIII
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node parent;
        }

        public Node LowestCommonAncestor(Node p, Node q)
        {
            Node pi = p;
            Node qi = q;

            while (pi != qi)
            {
                pi = pi.parent == null ? q : pi.parent;
                qi = qi.parent == null ? p : qi.parent;
            }

            return pi; // or return qi, as pi = qi at this point
        }
    }
}
