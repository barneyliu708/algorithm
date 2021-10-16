using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC109ConvertSortedLinkedListToBinarySearchTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            int count = CountListNode(head);
            return SortedListToBST(head, count);
        }

        private TreeNode SortedListToBST(ListNode head, int n)
        {
            // should use count n to check rather than the head.next
            if (n == 0)
            {
                return null;
            }

            // find the mid point and construct the root node
            int mid = (n - 1) / 2;
            ListNode mid_node = head;
            while (mid > 0)
            {
                mid--;
                mid_node = mid_node.next;
            }
            TreeNode root_node = new TreeNode(mid_node.val);

            // construct left BST
            root_node.left = SortedListToBST(head, (n - 1) / 2);
            root_node.right = SortedListToBST(mid_node.next, n - ((n - 1) / 2) - 1);

            return root_node;
        }

        private int CountListNode(ListNode head)
        {
            int count = 0;
            ListNode pointer = head;
            while (pointer != null)
            {
                count++;
                pointer = pointer.next;
            }
            return count;
        }
    }
}
