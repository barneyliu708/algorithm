using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC510InorderSuccessorInBSTII
    {
        public Node InorderSuccessor(Node x)
        {

            if (x.right != null)
            { // the successor is the leftmost node of x's right subtree
                Node cur = x.right;
                while (cur.left != null)
                {
                    cur = cur.left;
                }
                return cur;
            }

            while (x.parent != null && x.parent.right == x)
            {
                x = x.parent;
            }

            return x.parent;
        }
    }
}
