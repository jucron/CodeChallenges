/*
 * 
Challenge: Container With Most Water

Given an array of integers height, where each element represents the height of a vertical line, 
find two lines that together with the x-axis form a container that holds the maximum amount of water.

🧠 Example
Input:  height = [1,8,6,2,5,4,8,3,7]
Output: 49

Input:  [1,1]
Output: 1

Input:  [4,3,2,1,4]
Output: 16

Input:  [1,2,1]
Output: 2

 * */

using System;
using System.Collections.Generic;

namespace CodeChallenges.TwoPointers;


internal class ContainerWithMostWater
{
    public static void Run()
    {
        List<int[]> input = [[1, 8, 6, 2, 5, 4, 8, 3, 7], [1, 1], [4, 3, 2, 1, 4], [1, 2, 1]];
        foreach (int[] array in input) {

            var result = GetContainerWithMostWater(array);
            Console.WriteLine($"{string.Join(",",array)}: {result}");
        }
    }

    private static int GetContainerWithMostWater(int[] nums)
    {
        /*
         * [1,8,6,2,5,4,8,3,7]
         * [1,             ,7] -> left: 0, right: 8, length: (right-left) = 8, height: (smallest) 1, area: (height*length) = 8 | smaller is left! left++
         * [ ,8,           ,7]
         * ...
         * */

        int left = 0;
        int right = nums.Length - 1;
        int maxArea = 0;

        while (left <= right)
        {
            int length = right - left;
            int height = Math.Min(nums[left], nums[right]);
            int currentArea = length * height;
            maxArea = Math.Max(maxArea, currentArea);

            if (nums[left] < nums[right]) { 
                left++; 
            } else
            {
                right--;
            }
        }
        return maxArea;
    }
}