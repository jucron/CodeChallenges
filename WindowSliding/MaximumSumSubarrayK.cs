/*
 * 
Maximum Sum Subarray of Size K
Difficulty: Easy-Medium
Problem:
Given an array of integers nums and an integer k, find the maximum sum of any contiguous subarray of size k.
Examples:
Input:  nums = [2, 1, 5, 1, 3, 2], k = 3
Output: 9
Explanation: Subarray [5, 1, 3] has the maximum sum of 9.

Input:  nums = [2, 3, 4, 1, 5], k = 2
Output: 7
Explanation: Subarray [3, 4] has the maximum sum of 7.

Input:  nums = [1, 1, 1, 1, 1], k = 3
Output: 3
Constraints:

1 <= k <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4
 * */

using System;
using System.Collections.Generic;

namespace CodeChallenges.WindowSliding
{

    internal class MaximumSumSubarrayK
    {
        public static void Run()
        {
            List<(int[] nums, int k)> input = [(new[]{2, 1, 5, 1, 3, 2}, 3), (new[] { 2, 3, 4, 1, 5 }, 2), (new[] { 1, 1, 1, 1, 1 }, 3)];


            input.ForEach(x => Console.WriteLine($"{x}: {GetMaximumSumSubarrayK(x.nums,x.k)}"));
        }

        private static int GetMaximumSumSubarrayK(int[] nums, int k)
        {
            /*
             * [2, 1, 5, 1, 3, 2], k = 3
             * 2
             * 2, 1
             * 2, 1, 5 -> sum -> compute maxSum
             *    1, 5, 1 -> sum -> compute maxSum
             *       5, 1, 3 -> sum -> compute maxSum
             *          1, 3, 2 -> sum -> compute maxSum -> stop
             * */

            int left = 0;
            int maxSum = 0;
            int currentArraySize = 0;

            for (int right = 0; right < nums.Length;){
                currentArraySize++;

                if (currentArraySize <)
                {
                    
                }

            }


            return 0;
        }
    }
}