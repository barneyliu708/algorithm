using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC061RotateList
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

        public ListNode RotateRight(ListNode head, int k)
        {

            if (head == null)
            {
                return head;
            }

            ListNode dummy = new ListNode();
            dummy.next = head;

            // count length
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.next;
            }
            k = k % length;

            if (k == 0)
            {
                return dummy.next;
            }

            ListNode fast = dummy;
            ListNode slow = dummy;
            while (k > 0)
            {
                fast = fast.next;
                k--;
            }
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            // swap
            fast.next = dummy.next;
            dummy.next = slow.next;
            slow.next = null;

            return dummy.next;
        }
    }
}
