using System;

namespace leetcode.problems.program2
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if(l1 == null || l2 == null) {
                throw new ArgumentException();
            }

            int sum = l1.val + l2.val;
            int remainder = sum / 10;
            
            ListNode sumNode = new ListNode(sum % 10);

            AddTwoNumbers(l1.next, l2.next, sumNode, remainder);

            return sumNode;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, ListNode sumNode, int remainder)
        {
            if(l1 == null && l2 == null && remainder > 0) {
                sumNode.next = new ListNode(remainder);
                return sumNode.next;
            } else if(l1 == null && l2 == null) {
                return sumNode;
            }

            int sum;
            if(l1 == null) {
                sum = l2.val + remainder;
                remainder = sum / 10;
                sumNode.next = new ListNode(sum % 10);
                return AddTwoNumbers(null, l2.next, sumNode.next, remainder);
            } else if(l2 == null) {
                sum = l1.val + remainder;
                remainder = sum / 10;
                sumNode.next = new ListNode(sum % 10);
                return AddTwoNumbers(l1.next, null, sumNode.next, remainder);
            }

            sum = l1.val + l2.val + remainder;
            remainder = sum / 10;
            sumNode.next = new ListNode(sum % 10);
            return AddTwoNumbers(l1.next, l2.next, sumNode.next, remainder);
        }
    }

}