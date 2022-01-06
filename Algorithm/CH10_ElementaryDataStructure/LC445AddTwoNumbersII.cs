using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC445AddTwoNumbersII
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
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();

            ListNode p = l1;
            while (p != null)
            {
                stack1.Push(p.val);
                p = p.next;
            }
            p = l2;
            while (p != null)
            {
                stack2.Push(p.val);
                p = p.next;
            }

            ListNode ans = new ListNode(0, null);
            int sum = 0;
            while (stack1.Count != 0 || stack2.Count != 0)
            {

                if (stack1.Count != 0)
                {
                    sum += stack1.Pop();
                }
                if (stack2.Count != 0)
                {
                    sum += stack2.Pop();
                }
                ans.val = sum % 10;
                ListNode head = new ListNode(sum / 10);
                head.next = ans;
                ans = head;
                sum /= 10;
            }

            return ans.val == 0 ? ans.next : ans;
        }
    }
}
