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
                    
                    List<int> missingNumbers = new List<int>();

                    for (int i = 0; i < nums1.Length; i++)
                    {
                        int index = Math.Abs(nums1[i]) - 1;
                        if (nums1[index] > 0)
                        {
                            nums1[index] = -nums1[index];
                        }
                    }

                    for (int i = 0; i < nums1.Length; i++)
                    {
                        if (nums1[i] > 0)
                        {
                            missingNumbers.Add(i + 1);
                        }
                    }
                    return missingNumbers;                
            }
            catch (Exception)
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
              
                    int i = 0, j = nums2.Length - 1;

                    while (i < j)
                    {
                        if (nums2[i] % 2 > nums2[j] % 2)
                        {
                            int temp = nums2[i];
                            nums2[i] = nums2[j];
                            nums2[j] = temp;
                        }

                        if (nums2[i] % 2 == 0) i++;
                        if (nums2[j] % 2 == 1) j--;
                    }

                    return nums2;     
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums3, int target)
        {
            try
            {
                // Write your code here

                    Dictionary<int, int> map = new Dictionary<int, int>();

                    for (int i = 0; i < nums3.Length; i++)
                    {
                        int complement = target - nums3[i];
                        if (map.ContainsKey(complement))
                        {

                            return new int[] { map[complement], i };
                        }
                        map[nums3[i]] = i;
                    }

                    return new int[0]; 
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums4)
        {
            try
            {
                // Write your code here

                    Array.Sort(nums4);
                    int n = nums4.Length;

                    return Math.Max(nums4[n-1] * nums4[n-2] * nums4[n-3],Math.Max(nums4[0] * nums4[1] * nums4[n-1], nums4[0] * nums4[n-1]*nums4[n-2]));
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here

                    if (decimalNumber == 0) return "0";

                    StringBuilder binary = new StringBuilder();
                    while (decimalNumber > 0)
                    {
                        binary.Insert(0, decimalNumber % 2);
                        decimalNumber /= 2;
                    }

                    return binary.ToString();                             
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums5)
        {
            try
            {
                // Write your code here
                         
                    int left = 0, right = nums5.Length - 1;

                    while (left < right)
                    {
                        int mid = (left + right) / 2;
                        if (nums5[mid] > nums5[right]) left = mid + 1;
                        else right = mid;
                    }

                    return nums5[left];               
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                    int temp = x;
                    if (x < 0 || (x % 10 == 0 && x != 0)) return false;

                    int revertedNumber = 0;
                    while (x > 0)
                    {
                        revertedNumber = revertedNumber * 10 + x % 10;
                        x /= 10;
                    }
                    return temp == revertedNumber;
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here

                    if (n <= 1) return n;

                    int[] fib = new int[n + 1];
                    fib[0] = 0;
                    fib[1] = 1;

                    for (int i = 2; i <= n; i++)
                    {
                        fib[i] = fib[i-1] + fib[i-2];
                    }

                    return fib[n];            
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
