using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC002AddTwoNumbers
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            ListNode dummy = new ListNode();
            ListNode cur = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int curSum = carry;
                if (l1 != null)
                {
                    curSum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    curSum += l2.val;
                    l2 = l2.next;
                }

                cur.next = new ListNode(curSum % 10);
                carry = curSum / 10;

                cur = cur.next;
            }

            return dummy.next;
        }
    }
}
