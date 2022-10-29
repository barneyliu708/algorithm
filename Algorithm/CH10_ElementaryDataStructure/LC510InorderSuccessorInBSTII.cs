using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC510InorderSuccessorInBSTII
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node parent;
        }
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

        public class SecondDone
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
                { // the successor is somewhere upper in the tree
                    x = x.parent;
                }

                return x.parent;
            }
        }

        public class ThirdDone
        {
            public Node InorderSuccessor(Node x)
            {
                if (x == null)
                {
                    return null;
                }
                Node successor = x;
                if (x.right != null)
                {
                    successor = x.right;
                    while (successor.left != null)
                    {
                        successor = successor.left;
                    }
                    return successor;
                }
                while (successor.parent != null && successor.parent.right == successor)
                {
                    successor = successor.parent;
                }
                return successor.parent;
            }
        }
    }
}
