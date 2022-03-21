using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC024SwapNodesInPairs
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
        public ListNode SwapPairs(ListNode head)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;

            ListNode pre = dummy;
            ListNode cur = head;
            while (cur != null && cur.next != null)
            {
                ListNode next = cur.next;

                // swap
                cur.next = next.next;
                pre.next = next;
                next.next = cur;

                // move forward for the next iteration
                pre = cur;
                cur = cur.next;
            }

            return dummy.next;
        }
    }
}
