using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC234PalindromeLinkedList
    {
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
        public bool IsPalindrome(ListNode head)
        {

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.next;
            }

            int count = stack.Count / 2;
            cur = head;
            while (count-- > 0)
            {
                if (cur.val != stack.Pop().val)
                {
                    return false;
                }
                cur = cur.next;
            }
            return true;
        }
    }
}
