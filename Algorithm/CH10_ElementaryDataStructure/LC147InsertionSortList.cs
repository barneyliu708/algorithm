using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC147InsertionSortList
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
        public ListNode InsertionSortList(ListNode head)
        {
            ListNode ans = new ListNode();

            ListNode cur;
            while (head != null)
            {
                cur = head;
                head = head.next;
                cur.next = null; // break the link to the original list

                ListNode insert = ans;
                while (insert.next != null && insert.next.val < cur.val)
                {
                    insert = insert.next;
                }

                ListNode next = insert.next;
                insert.next = cur;
                cur.next = next;
            }

            return ans.next;
        }
    }
}
