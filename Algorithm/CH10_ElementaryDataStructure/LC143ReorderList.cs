using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC143ReorderList
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
        public void ReorderList(ListNode head)
        {

            ListNode cur = head;
            Stack<ListNode> stack = new Stack<ListNode>();
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.next;
            }

            int count = stack.Count / 2;
            cur = head;
            while (count-- > 0)
            {
                ListNode tail = stack.Pop();
                ListNode next = cur.next;
                cur.next = tail;
                tail.next = next;
                cur = next;
            }
            cur.next = null;
        }
    }
}
