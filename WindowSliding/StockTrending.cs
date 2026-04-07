/*
 * 
StockTrending
Difficulty: Easy-Medium
Problem:
Given an array of integers nums, representing stock prices in a timeline, find the combination of best sell/buy indexes.
Examples:
Input:  nums = [10, 200, 20]
Output: [0,1]
Explanation: Buy at index 0 and sell at 1.

Input:  nums = [10,200,20,400,550,520]
Output: [0,1][2,4]

Input:  nums = [25, 35, 100, 80, 150, 15, 50, 200, 210, 20, 30]
Output: [0,2][3,4][5,8]


 * */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.WindowSliding
{

    internal class StockTrending
    {
        public static void Run()
        {
            List<int[]> input = [[10, 200, 20], [10, 200, 20, 400, 550, 520], [25, 35, 100, 80, 150, 15, 50, 200, 210, 20, 30]];
            foreach (int[] stock in input) {

                var result = GetStockTrending(stock);


                Console.WriteLine($"{Print(stock)}: {Print(result.Select(r =>$"[{r.buy},{r.sell}]"))}");
            }
        }

        private static string Print(int[] array)
        {
            return $"[{string.Join(",",array)}]";
        }
        private static string Print(IEnumerable<string> list)
        {
            return $"{string.Join(",", list)}";
        }

        private static List<(int buy, int sell)> GetStockTrending(int[] nums)
        {
            /*
             * [10, 200, 20, 400, 550] (lenght: 5, lastIndex: 4)
             * 
             * [10, -> not acquired stock -> if next is bigger -> buy this one
             * [10, 200 -> acquired stock -> if next is smaller -> sell this one -> add array to collection
             * [10, 200, 20 -> not acquired stock -> if next is bigger -> buy this one
             * ...
             * */
            var result = new List<(int buy, int sell)>();

            int lastIndex = nums.Length - 1;

            (int buy, int sell) currentTransaction = (0, 0);
            bool hasAcquiredStock = false;

            for (int i = 0; i < lastIndex; i++)
            {
                if (hasAcquiredStock)
                {
                    if (nums[i + 1] < nums[i])
                    {
                        currentTransaction.sell = i;
                        result.Add(currentTransaction);
                        hasAcquiredStock = false;
                    }
                } else
                {
                    if (nums[i + 1] > nums[i])
                    {
                        currentTransaction.buy = i;
                        hasAcquiredStock = true;
                    }
                }
            }

            return result;
        }
           
    }
}