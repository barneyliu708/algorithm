using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC160IntersectionOfTwoLinkedLists
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            HashSet<ListNode> hashset = new HashSet<ListNode>();

            while (headA != null)
            {
                hashset.Add(headA);
                headA = headA.next;
            }

            while (headB != null)
            {
                if (hashset.Contains(headB))
                {
                    return headB;
                }
                headB = headB.next;
            }

            return null;
        }

        public class TwoPointerApproach
        {
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                ListNode p1 = headA;
                ListNode p2 = headB;
                while (p1 != p2)
                {
                    p1 = p1 == null ? headB : p1.next;
                    p2 = p2 == null ? headA : p2.next;
                }
                return p1;
                // Note: In the case lists do not intersect, the pointers for A and B
                // will still line up in the 2nd iteration, just that here won't be
                // a common node down the list and both will reach their respective ends
                // at the same time. So pA will be NULL in that case.
            }
        }
    }
}
