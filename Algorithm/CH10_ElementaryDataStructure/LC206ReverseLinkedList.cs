using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC206ReverseLinkedList
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
        public ListNode ReverseList(ListNode head)
        {

            if (head == null || head.next == null)
            {
                return head;
            }

            // ListNode headnext = head.next;
            // head.next = null; // break the chain to avoid infinite loop

            // ListNode reversedNext = ReverseList(headnext);

            // ListNode cur = reversedNext;
            // while (cur.next != null) {
            //     cur = cur.next;
            // }
            // cur.next = head;

            ListNode reversedNext = ReverseList(head.next);
            head.next.next = head;
            head.next = null;

            return reversedNext;
        }
    }
}
