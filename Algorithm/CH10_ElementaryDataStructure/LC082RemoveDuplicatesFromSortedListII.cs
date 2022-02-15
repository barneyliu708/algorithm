using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC082RemoveDuplicatesFromSortedListII
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

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;

            ListNode l = dummy;
            ListNode r = head;
            while (r != null)
            {
                if (r.next != null && r.val == r.next.val)
                {
                    int val = r.val;
                    while (r != null && r.val == val)
                    {
                        r = r.next;
                    }
                }
                else // r.next == null || r.val != r.next.val
                { 
                    l.next = r;
                    l = l.next;
                    r = r.next;
                }
            }

            l.next = null; // break the chain after the left node

            return dummy.next;
        }
    }
}
