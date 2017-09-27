using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems
{
    public class Solutions
    {
        /// <summary>
        /// Reverses an integer.
        /// </summary>
        /// <param name="x">Integer to be reversed</param>
        /// <returns>The reversed integer</returns>
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

        /// <summary>
        /// Determines if the integer is a palindrome.
        /// </summary>
        /// <param name="x">Integer to be checked</param>
        /// <returns>Whether the passed integer is indeed a palindrome</returns>
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

        /// <summary>
        /// Adds to reverse-ordered linked lists of integers.
        /// </summary>
        /// <param name="l1">The first reverse-ordered linked list</param>
        /// <param name="l2">The second reverse-ordered linked list</param>
        /// <returns>A reverse-ordered linked list of the sum of the two linked lists</returns>
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

        /// <summary>
        /// Converts Roman Numerals to an integer value.
        /// </summary>
        /// <param name="s">The string representing a series of Roman Numerals</param>
        /// <returns>The integer value of the series of Roman Numerals</returns>
        public int RomanToInt(string s)
        {
            int sum = 0, valToAdd = 0, lastValToAdd = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case ('I'):
                        valToAdd = 1;
                        break;
                    case ('V'):
                        valToAdd = 5;
                        break;
                    case ('X'):
                        valToAdd = 10;
                        break;
                    case ('L'):
                        valToAdd = 50;
                        break;
                    case ('C'):
                        valToAdd = 100;
                        break;
                    case ('D'):
                        valToAdd = 500;
                        break;
                    case ('M'):
                        valToAdd = 1000;
                        break;
                }
                if (valToAdd > lastValToAdd && lastValToAdd != 0)
                {
                    sum -= lastValToAdd * 2;
                    sum += valToAdd;
                }
                else
                {
                    sum += valToAdd;
                }
                lastValToAdd = valToAdd;
            }
            return sum;
        }

        /// <summary>
        /// Finds the longest prefix from a list of strings
        /// </summary>
        /// <param name="strs">The list of strings</param>
        /// <returns>The longest prefix</returns>
        public string LongestCommonPrefix(string[] strs)
        {
            string lp = "";
            if (strs.Length <= 0) { return lp; }
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                bool addChar = true;
                for (int k = 1; k < strs.Length; k++)
                {
                    if (i >= strs[k].Length)
                    {
                        addChar = false;
                        break;
                    }
                    if (strs[k][i] != c)
                    {
                        addChar = false;
                        break;
                    }
                }
                if (addChar) { lp += c; continue; }
                break;
            }
            return lp;
        }

        /// <summary>
        /// Removes duplicates from an array of integers, shifting duplicates to the back
        /// and returning the new length of non-dupe integers.
        /// </summary>
        /// <param name="nums">Array of ints to remove dupes from</param>
        /// <returns>Length of non-dupe array</returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2) { return nums.Length; }
            int i = 0, j;
            for (j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    nums[++i] = nums[j];
                    continue;
                }
            }
            return ++i;
        }
    }

    
}
