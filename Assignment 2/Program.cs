using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ma);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        //Concept: Created a dictionary with all elements with its count.
        //Iterate to check for an occurance of the element.

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                var result = new System.Collections.ArrayList();
                var count = new Dictionary<int, int>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (count.ContainsKey(nums1[i]))
                    {
                        count[nums1[i]]++;
                    }
                    else
                    {
                        count[nums1[i]] = 1;
                    }
                    for (int x = 0;  x< nums2.Length; x++)
                    {
                        if (count.ContainsKey(nums2[x]))
                        {
                            Console.Write(nums2[x]);
                            count[nums2[x]]--;
                            if (count[nums2[x]] < 1)
                            {
                                count.Remove(nums2[x]);
                            }
                        }

                    }

                    Console.Write("\n");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
       //Concept: Conduct a binary search throughout the array to determine where the element should be placed

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int left = 0, right = nums.Length;

                while (left < right)
                {
                    var midpoint = left + (right - left) / 2;
                    if (nums[midpoint] == target) return midpoint;
                    else if (nums[midpoint] < target) left = midpoint + 1;
                    else right = midpoint;
                }

                return left;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /*Concept: 
         * Iterate over the array to check the occurance of each key. Need to also look for the largest number 
         * and return the key. 
         */


        private static int LuckyNumber(int[] nums)
        {
            try
            {
                var frequency = new Dictionary<int, int>();
                foreach (var num in nums)
                {
                    if (frequency.ContainsKey(num))
                        frequency[num]++;
                    else
                        frequency[num] = 1;
                }

                var result = -1;
                foreach (var key in frequency.Keys)
                {
                    if (key > result && frequency[key] == key)
                        result = key;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Question 4 
        /*Concept: 
         * Create an array and assign the variables as stated in the problem.
         * Iterate over the array to calculate the value. Maximum value will be generated after comparison with 
         * current index 
         */
        private static int GenerateNums(int n)
        {
            try
            {
                {
                    if (n <= 0)
                        return 0;

                    var num = new int[n + 1];
                    num[0] = 0;
                    num[1] = 1;
                    var max = 1;
                    for (var i = 2; i < n + 1; i++)
                    {
                        if (i % 2 == 0)
                            num[2 * (i / 2)] = num[i / 2];
                        else
                            num[(2 * (i / 2)) + 1] = num[i / 2] + num[i / 2 + 1];

                        max = Math.Max(max, num[i]);
                    }

                    return max;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /* Concept: 
         * Create a set with all the destinations. Remove all the destinations that have outward routes
         * Return the first destination that does not have any routes outward
         */

        
        public static string DestCity(List<List<string>> paths)
        {
            try
            {  
                        var city = new HashSet<string>();
                        foreach (var path in paths)
                            city.Add(path[1]);
                        foreach (var path in paths)
                            city.Remove(path[0]);

                        return city.First();
                    }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        
       
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                var left = 0;
                var right = nums.Length - 1;
                for (; true;)
                {
                    var total = nums[left] + nums[right];
                    if (total == target)
                        break;
                    else if (total < target)
                        left += 1;
                    else
                        right -= 1;
                }

                Console.WriteLine("[{0}, {1}]", left + 1, right + 1);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /*Create a dictionary with all student scores that is sorted.
         *Reverse the order so that it will be from largest to smallest and then take the first five.
         */

        private static void HighFive(int[,] items)
        {
            try
            {

                var score = new Dictionary<int,SortedSet <int>>();
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    if (!score.ContainsKey(items[i, 0]))
                    {
                        score[items[i, 0]] = new SortedSet<int>();
                    }

                    score[items[i, 0]].Add(items[i, 1]);
                }


                foreach (KeyValuePair<int, SortedSet<int>> entry in score)
                {

                    Console.Write("[{0}, {1}]", entry.Key, entry.Value.Reverse().Take(5).Sum() / 5);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /*Create an array called final. Then rotate all elements until first element is reached 
         */

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                
                int[] final = new int[arr.Length];
                int l = arr.Length;
                
                for (int i = 0; i < l; i++)
                {
                    final[(i + n) % l] = arr[i];
                }
                for (int i = 0; i < l; i++)
                {
                    arr[i] = final[i];

                }
                Console.WriteLine("[" + String.Join(",", arr) + "]");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /*Initialize 2 variables called maxsubarray and currentsubarray. 
         * Iterate over the array, making sure that to add it to the currentsubarray. 
         * Keep updating the maxsubarray when new maximum is found
         */

        private static int MaximumSum(int[] arr)
        {
            try
            {
                int maxsubarray = int.MinValue;
                int currentsubarray = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    currentsubarray += arr[i];
                   
                    maxsubarray = Math.Max(maxsubarray, currentsubarray);

                    if (currentsubarray < 0)
                        currentsubarray = 0;
                }

                return maxsubarray;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /*Create the array and assign the variables.
         * Create a loop to check for the minimum cost
         * Check and choose the minimum value from the first and second step and then it adds the cost
         * from the following steps. 
         */
        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int cost1 = 0, cost2 = 0;
                var index = 2;
                for (; index < costs.Length; index++)
                {
                    var curr = Math.Min(cost1 + costs[index - 2], cost2 + costs[index - 1]);
                    cost1 = cost2;
                    cost2 = curr;
                }

                return Math.Min(cost1 + costs[index - 2], cost2 + costs[index - 1]);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
//Self-reflection: 
/*It did feel more better to do this assignment since I am getting more comfortable with using Visual Studio. However,
 *However, I am still trying to understand the concepts that are being taught in this class. I find myself
 *researching alot to understand the syntax of these problems. In my opinion, I think we shud have more hands on practice and understand the logic. 
 */