using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1,1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums1)
        {
            try
            {
                // Write your code here

                // Initialize a list to store missing numbers
                List<int> missingNumbers = new List<int>();

                    // Go through the array and mark the elements we've seen by turning their value into a negative number.
                    for (int i = 0; i < nums1.Length; i++)
                    {
                        int index = Math.Abs(nums1[i]) - 1;
                        if (nums1[index] > 0)
                        {
                            nums1[index] = -nums1[index];
                        }
                    }

                // Find the unmarked (positive) numbers and add their corresponding values to the result list.
                for (int i = 0; i < nums1.Length; i++)
                    {
                        if (nums1[i] > 0)
                        {
                            missingNumbers.Add(i + 1);
                        }
                    }
                    return missingNumbers;      // Return the list of missing numbers          
            }
            catch (Exception) // Handle the exceptions.
            {
                throw;
            }
        }
        

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums2)
        {
            try
            {
                // Write your code here               

                // Initialize two pointers, 'i' starting at the beginning and 'j' at the end of the array.
                int i = 0, j = nums2.Length - 1;

                    while (i < j) // Loop until the two pointers meet.
                    {
                        if (nums2[i] % 2 > nums2[j] % 2) 
                        {
                            int temp = nums2[i];
                            nums2[i] = nums2[j];
                            nums2[j] = temp;
                        } // If the element at 'i' is odd and the element at 'j' is even, swap them.

                        if (nums2[i] % 2 == 0) i++; // Move the 'i' pointer forward if the element at 'i' is even.
                        if (nums2[j] % 2 == 1) j--; // Move the 'j' pointer backward if the element at 'j' is odd. 
                    }

                    return nums2;  // Return the array with even numbers at the front and odd numbers at the back.   
            }
            catch (Exception)
            {
                throw; // To handle the exceptions.
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums3, int target)
        {
            try
            {
                // Create a dictionary to store numbers and their indices.
                Dictionary<int, int> map = new Dictionary<int, int>();

                // Loop through each number in the array.
                for (int i = 0; i < nums3.Length; i++)
                {
                    // Calculate the complement (target minus the current number).
                    int complement = target - nums3[i];

                    // Check if the complement is already in the dictionary.
                    if (map.ContainsKey(complement))
                    {
                        // If found, return the indices of the complement and current number.
                        return new int[] { map[complement], i };
                    }

                    // Add the current number and its index to the dictionary.
                    map[nums3[i]] = i;
                }

                // Return an empty array if no pair is found that adds up to the target.
                return new int[0];
            }
            catch (Exception)
            {
              throw; // To handle the exceptions.
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums4)
        {
            try
            {
                // Sort the array in ascending order.
                Array.Sort(nums4);
                int n = nums4.Length;

                // Return the maximum product of three numbers.
                // This considers two cases: 
                // (1) The product of the three largest numbers.
                // (2) The product of two smallest (negative) numbers and the largest number, and
                // as multiplying two negative numbers results in a positive product.
                return Math.Max(nums4[n-1] * nums4[n-2] * nums4[n-3],nums4[0] * nums4[1] * nums4[n-1]);
            }
            catch (Exception)
            {
                // To Handle any exceptions that occur.
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // If the input decimal number is 0, return "0" as the binary representation.
                if (decimalNumber == 0) return "0";

                // Initialize a StringBuilder to store the binary representation.
                StringBuilder binary = new StringBuilder();

                // Convert the decimal number to binary by repeatedly dividing by 2
                // and inserting the remainder (0 or 1) at the start of the StringBuilder.
                while (decimalNumber > 0)
                {
                    binary.Insert(0, decimalNumber % 2);
                    decimalNumber /= 2;
                }

                // Return the final binary string after conversion.
                return binary.ToString();
            }
            catch (Exception)
            {
                // To Handle any exceptions that might occur.
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums5)
        {
            try
            {
                // Initialize two pointers: left at the beginning and right at the end of the array.
                int left = 0, right = nums5.Length - 1;

                // Use a while loop to continue searching as long as left pointer is less than right pointer.
                while (left < right)
                {
                    // Find the middle index of the current search range.
                    int mid = (left + right) / 2;

                    // If the middle element is greater than the rightmost element, 
                    // the minimum is in the right half, so move the left pointer to mid + 1.
                    if (nums5[mid] > nums5[right])
                        left = mid + 1;
                    // Otherwise, the minimum is in the left half, so move the right pointer to mid.
                    else
                        right = mid;
                }

                // Return the element at the left pointer, which is the minimum.
                return nums5[left];
            }
            catch (Exception)
            {
                // To Handle any exceptions.
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Store the original number in a temporary variable for later comparison.
                int temp = x;

                // If the number is negative or ends with 0 (but isn't 0 itself), it's not a palindrome.
                if (x < 0 || (x % 10 == 0 && x != 0))
                    return false;

                // Initialize a variable to hold the reversed number.
                int revertedNumber = 0;

                // Reverse the digits of the number.
                while (x > 0)
                {
                    // Append the last digit of 'x' to the reversed number.
                    revertedNumber = revertedNumber * 10 + x % 10;
                    // Remove the last digit from 'x'.
                    x /= 10;
                }

                // Check if the reversed number is equal to the original number.
                return temp == revertedNumber;
            }
            catch (Exception)
            {
                // To Handle any errors/ exceptions.
                throw;
            }
        }
        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Check if the input number is less than or equal to 1
                // If it is, return the number itself (0 or 1)
                if (n <= 1) return n;

                // Create an array to hold Fibonacci numbers up to n
                int[] fib = new int[n + 1];

                // Initialize the first two Fibonacci numbers
                fib[0] = 0; // The 0th Fibonacci number is 0
                fib[1] = 1; // The 1st Fibonacci number is 1

                // Loop through from 2 to n to calculate Fibonacci numbers
                for (int i = 2; i <= n; i++)
                {
                    // Each Fibonacci number is the sum of the two preceding ones
                    fib[i] = fib[i-1] + fib[i-2];
                }

                // Return the nth Fibonacci number
                return fib[n];
            }
            catch (Exception)
            {
                // If an error occurs, rethrow the exception
                throw;
            }
        }
    }
}
