using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC141LinkedListCycle
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x = 0)
            {
                val = x;
                next = null;
            }
        }

        public bool HasCycle(ListNode head)
        {

            HashSet<ListNode> hashset = new HashSet<ListNode>();

            while (head != null)
            {
                if (hashset.Contains(head))
                {
                    return true;
                }
                hashset.Add(head);
                head = head.next;
            }

            return false;
        }

        public class TwoPointerApproach
        {
            public bool HasCycle(ListNode head)
            {
                ListNode dummy = new ListNode();
                dummy.next = head;
                ListNode f = dummy.next;
                ListNode s = dummy;
                while (f != s)
                {
                    if (f == null || f.next == null)
                    {
                        return false;
                    }
                    f = f.next.next;
                    s = s.next;
                }

                return true;
            }
        }
    }
}
