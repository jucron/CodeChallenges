/*
 * 
Challenge: 3Sum (Find Triplets That Sum to Zero)

Given an integer array nums, return all the unique triplets [nums[i], nums[j], nums[k]] such that:

i != j, i != k, j != k
nums[i] + nums[j] + nums[k] == 0

🧠 Example
Input:  nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2], [-1,0,1]]

Input:  [0,0,0,0]
Output: [[0,0,0]]

Input:  [-2,0,1,1,2]
Output: [[-2,0,2], [-2,1,1]]

Input:  [-1,0,1,2,-1,-4,-2,-3,3,0,4]
Output: [[-4,0,4], [-3,-1,4], [-3,0,3], [-2,-1,3], [-2,0,2], [-1,-1,2], [-1,0,1]]

 * */

using System;
using System.Collections.Generic;

namespace CodeChallenges.TwoPointers;


internal class ThreeSumTriplets
{
    public static void Run()
    {
        List<int[]> input = [[-1, 0, 1, 2, -1, -4], [0, 0, 0, 0], [-2, 0, 1, 1, 2], [-1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4]];
        foreach (int[] array in input) {

            var result = GetThreeSumTriplets(array);
            string resultString = "";
            result.ForEach(r => resultString+=$"[{string.Join(",",r)}]");
            Console.WriteLine($"{string.Join(",", array)}: [{resultString}]");
        }
    }

    private static List<int[]> GetThreeSumTriplets(int[] nums)
    {
        /*
         * sort it! [-1, 0, 1, 2, -1, -4]
         * [-4, -1, -1, 0, 1, 2] -> size: 6
         * [-4  -1            2] -> i=0; l:1; r:5; sum = -3 ; sum < 0 -> left++ 
         * [-4      -1        2] -> i=0; l:2; r:5; sum = -3 ; sum < 0 -> left++ 
         * [-4          0     2] -> i=0; l:3; r:4; sum = -2 ; sum < 0 -> left++ 
         * [-4          0     2] -> i=0; l:3; r:4; sum = -2 ; sum < 0 -> left++ 
         * ...
         * [    -1, -1, 0, 1, 2] -> i=1; l:2; r:5; sum = -3 ; sum < 0 -> left++ 
         *  
         *  
         * */

        List<int[]> result = new List<int[]>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            // skip duplicate i
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i+1;
            int right = nums.Length-1;

            while (left < right)
            {
                int currentNumber = nums[i];
                int leftNumber = nums[left];
                int rightNumber = nums[right];

                int sum = currentNumber + leftNumber + rightNumber;

                if (sum == 0)
                {
                    result.Add([nums[i], nums[left], nums[right]]);

                    // skip duplicates
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }
        }
        return result;
    }
}