using System;
using CodeChallenges.TwoPointers;
using CodeChallenges.WindowSliding;

namespace CodeChallenges
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            switch (args[0]) 
            {
                case "LongestSubstring":
                    LongestSubstring.Run();
                    break;

                case "MaximumSumSubarrayK":
                    MaximumSumSubarrayK.Run();
                    break;
                case "StockTrending":
                    StockTrending.Run();
                    break;
                case "ContainerWithMostWater":
                    ContainerWithMostWater.Run();
                    break;
                case "ThreeSumTriplets":
                    ThreeSumTriplets.Run();
                    break;
                default:
                    Console.WriteLine("Initialization is wrong, please double check launchSettings class name: " + args[0]);
                    break;
            }


        }
    }
}
