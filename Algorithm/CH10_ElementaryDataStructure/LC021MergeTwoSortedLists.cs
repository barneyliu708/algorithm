using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC021MergeTwoSortedLists
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
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode p = dummy;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    p.next = list1;
                    p = p.next;
                    list1 = list1.next;
                }
                else
                {
                    p.next = list2;
                    p = p.next;
                    list2 = list2.next;
                }
            }

            if (list1 != null)
            {
                p.next = list1;
            }

            if (list2 != null)
            {
                p.next = list2;
            }

            return dummy.next;
        }

        public class SecondDone
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode dummy = new ListNode();
                ListNode cur = dummy;
                while (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        cur.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        cur.next = list2;
                        list2 = list2.next;
                    }
                    cur = cur.next;
                }

                cur.next = list1 ?? list2;
                return dummy.next;
            }
        }
    }
}
