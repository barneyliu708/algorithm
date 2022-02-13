using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC019RemoveNthNodeFromEndOfList
    {
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
    }
}
