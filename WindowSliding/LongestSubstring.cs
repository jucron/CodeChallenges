/*
 * 
🚀 Challenge: Longest Substring Without Repeating Characters
🧩 Problem

Given a string s, find the length of the longest substring without repeating characters.

📥 Example
Input: s = "abcabcbb"
Output: 3
Explanation: "abc" is the longest substring without repeating characters.
Input: s = "bbbbb"
Output: 1
Explanation: "b"
Input: s = "pwwkew"
Output: 3
Explanation: "wke"
 * */

using System;
using System.Collections.Generic;

namespace CodeChallenges.WindowSliding
{

    internal class LongestSubstring
    {
        public static void Run()
        {
            List<string> input = new List<string> { "abcabcbb", "bbbbb", "pwwkew"};
            Console.WriteLine("Original");
            input.ForEach(s => Console.WriteLine($"{s}: {LengthOfLongestSubstring(s)}"));
            Console.WriteLine("\nOptimized");
            input.ForEach(s => Console.WriteLine($"{s}: {LengthOfLongestSubstringOptimized(s)}"));
        }

        static int LengthOfLongestSubstring(string s)
        {
            /*
             * a -> check validity of window -> ok -> then add to collection and compute maxLength
             * ab -> check validity of window- > ok -> then add to collection and compute maxLength
             * abc -> check validity of window -> ok -> then add to collection and compute maxLength
             * abca -> check validity of window -> a is already in the list, move left and remove left char -> bca -> check validity of window -> ok -> then add to collection and compute maxLength
             * */

            int left = 0;
            int maxLength = 0;
            
            Dictionary<char, int> charCount = [];

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                charCount.TryGetValue(currentChar, out int currentCharcount);
                int newCurrentCharCount = currentCharcount + 1;
                charCount[currentChar] = newCurrentCharCount;

                // check validity
                while (charCount[currentChar] > 1)
                {
                    char leftChar = s[left];
                    charCount.TryGetValue(leftChar, out int leftCharCount);

                    //remove left char from window
                    charCount[leftChar] = leftCharCount == 0 ? 0 : leftCharCount-1; 
                    left++;
                }

                maxLength = Math.Max(maxLength, right - left+1);

            }
            return maxLength;
        }

        static int LengthOfLongestSubstringOptimized(string s)
        {
            /*
             * a -> check validity of window -> ok -> mark charIndex and compute maxLength
             * ab -> check validity of window- > ok -> mark charIndex and compute maxLength
             * abc -> check validity of window -> ok -> mark charIndex and compute maxLength
             * abca -> check validity of window -> a is already in the list, move left to the valid index (just after the duplicate)  -> bca -> check validity of window -> ok -> mark charIndex and compute maxLength
             * */
            int left = 0;
            int maxLength = 0;

            Dictionary<char, int> charIndex = [];

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                // check validity
                if (charIndex.TryGetValue(currentChar,out int currentCharIndex)) // if there is this char already 
                {
                    // move left to this index +1
                    left = currentCharIndex + 1;
                }

                // add the index to it
                charIndex[currentChar] = right;

                maxLength = Math.Max(maxLength, right - left + 1);

            }
            return maxLength;
        }
    }
}