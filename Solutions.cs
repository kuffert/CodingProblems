using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems
{
    public class Solutions
    {
        public static int reverse(int x)
        {
            long result = 0;
            while (x != 0)
            {
                result *= 10;
                result += (x % 10);
                x /= 10;
            }
            return (result > Int32.MaxValue || result < Int32.MinValue) ? 0 : (int)result;
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            int reversed = reverse(x);
            while (x != 0)
            {
                if (x % 10 != reversed % 10)
                {
                    return false;
                }
                x = x / 10;
                reversed = reversed / 10;
            }
            return true;    
        }

        public static ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            int remainder = 0;
            ListNode dummyHead = new ListNode(0);
            ListNode curr = dummyHead;
            while (l1 != null || l2 != null)
            {
                int d1 = 0, d2 = 0;
                if (l1 != null)
                {
                    d1 = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    d2 = l2.val;
                    l2 = l2.next;
                }
                curr.next = new ListNode((d1 + d2 + remainder) % 10);
                if (d1 + d2 + remainder >= 10)
                {
                    remainder = 1;
                }
                else
                {
                    remainder = 0;
                }
                curr = curr.next;
            }
            if (remainder == 1)
            {
                curr.next = new ListNode(1);
            }

            return dummyHead.next;
        }
    }
}
