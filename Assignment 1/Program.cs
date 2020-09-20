using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            PrintTriangle(n);

            int n2 = 6;
            PrintSeriesSum(n2);

            int[] A = new int[] { 4, 5, 2, 3 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            int k = 1;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "hijklmnopqrstuvwxyzabcdefg";
            string word = "gobulls";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "robky";
            string str2 = "rocky";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        public static void PrintTriangle(int n)
        {
            try
            {
                int i, j, count = 1;
                count = n - 1;      // set the count number to decide the space before "*"
                for (j = 1; j <= n; j++)
                {
                    for (i = 1; i <= count; i++)   // Use a loop to print the spaces
                        Console.Write(" ");
                    count--;
                    for (i = 1; i <= 2 * j - 1; i++)  // use a for loop to print the "*"
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n2)
        {
            try
            {
                int i, s = 0;

                Console.Write("The odds number are:");
                for (i = 1; i <= n2; i++)
                {
                    Console.Write("{0} ", 2 * i - 1); // use the loop to display the odds number
                    s = s + 2 * i - 1;                // sum of the odd number 
                }

                Console.Write("\nThe sum  is : {1} \n", n2, s);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] A)
        {
            try
            {
                bool isInc = true;  // set the bool logic
                bool isDec = true;
                for (int i = 0; i < A.Length - 1; i++)
                {
                    if (A[i] > A[i + 1])    // use if logic to confirm the order of the element in the array
                    {
                        isInc = false;
                    }
                    if (A[i] < A[i + 1])    // use if logic to confirm the order of the element in the array
                    {
                        isDec = false;
                    }
                }
                return isDec || isInc;   // return the bool logic base on the if logic above
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                Array.Sort(J);
                int count = 0; //

                for (int i = 0; i < J.Length - 1; i++)
                {
                    if (i > 0 && J[i] == J[i - 1])
                    {   // remove the duplicate value in array J
                        continue;
                    }
                    for (int j = i + 1; j < J.Length; j++)
                    {
                        if (j > i + 1 && J[j] == J[j - 1])
                        { //remove the duplicated value in array J
                            continue;
                        }
                        if (J[j] - J[i] == k)  // decide if the diff(differences between j & i in" Array") ==k.
                        {
                            count++;
                        }
                    }
                }
                return count;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                {
                    int count = 0;
                    char[] chars = word.ToCharArray();
                    int index = 0;   // set start index
                    foreach (char i in chars)
                    {
                        count += Math.Abs(keyboard.IndexOf(i) - index);  // decide the distance of element "i" between "i" 's index and the start index and get the sum of the index for each "i" in "word"
                        index = keyboard.IndexOf(i);
                    }
                    return count;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                int[] count = new int[26];
                for (int i = 0; i < str1.Length; ++i)
                {
                    count[str1[i] - 'a']++;  // find the times that each element in str1 appears
                    count[str2[i] - 'a']--;  // find the times that each element in str2 appears
                }
                int result = 0;
                for (int i = 0; i < 26; ++i)
                {
                    result += count[i] > 0 ? count[i] : 0;    // sum the appearance time for each element in str1 and str2
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}
