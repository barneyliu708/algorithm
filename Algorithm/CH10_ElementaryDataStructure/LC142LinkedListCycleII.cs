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

        public class TwoPointersApproach
        {
            public ListNode DetectCycle(ListNode head)
            {
                if (head == null)
                {
                    return null;
                }

                ListNode intersection = GetIntersection(head);
                if (intersection == null)
                {
                    return null;
                }

                ListNode p1 = head;
                ListNode p2 = intersection;
                while (p1 != p2)
                {
                    p1 = p1.next;
                    p2 = p2.next;
                }

                return p1;
            }

            private ListNode GetIntersection(ListNode head)
            {
                ListNode f = head;
                ListNode s = head;
                while (f != null && f.next != null)
                {
                    f = f.next.next;
                    s = s.next;
                    if (f == s)
                    {
                        return f;
                    }
                }
                return null;
            }
        }
    }
}
