using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC086PartitionList
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
        public ListNode Partition(ListNode head, int x)
        {

            ListNode first = new ListNode();
            ListNode f = first;
            ListNode second = new ListNode();
            ListNode s = second;

            while (head != null)
            {
                if (head.val < x)
                {
                    f.next = head;
                    f = f.next;
                }
                else
                {
                    s.next = head;
                    s = s.next;
                }
                head = head.next;
            }
            f.next = null;
            s.next = null;

            f.next = second.next;

            return first.next;
        }
    }
}
