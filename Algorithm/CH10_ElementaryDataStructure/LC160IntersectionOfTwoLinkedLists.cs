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
    }
}
