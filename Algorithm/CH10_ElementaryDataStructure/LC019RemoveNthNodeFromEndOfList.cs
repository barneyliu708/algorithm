using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC019RemoveNthNodeFromEndOfList
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            ListNode dummy = new ListNode();
            dummy.next = head;
            int length = 0;
            ListNode cur = head;
            while (cur != null)
            {
                length++;
                cur = cur.next;
            }

            length = length - n;
            cur = dummy;
            while (length > 0)
            {
                length--;
                cur = cur.next;
            }
            cur.next = cur.next.next;

            return dummy.next;
        }

        public class SecondDone_OnePass
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                ListNode dummy = new ListNode();
                dummy.next = head;
                ListNode ft = dummy;
                ListNode sl = dummy;
                while (n > 0)
                {
                    ft = ft.next;
                    n--;
                }
                while (ft.next != null)
                {
                    ft = ft.next;
                    sl = sl.next;
                }
                sl.next = sl.next.next;
                return dummy.next;
            }
        }
    }
}
