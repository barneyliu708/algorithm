using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC142LinkedListCycleII
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public ListNode DetectCycle(ListNode head)
        {

            HashSet<ListNode> hashset = new HashSet<ListNode>();

            while (head != null)
            {
                if (hashset.Contains(head))
                {
                    return head;
                }
                hashset.Add(head);
                head = head.next;
            }

            return null;
        }
    }
}
