using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC141LinkedListCycle
    {
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
    }
}
