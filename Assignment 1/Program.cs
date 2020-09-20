using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 3, 2, 2, 6 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        public static void PrintTriangle(int x)
        {
            try
            {
                int i, j, n, count = 1;
                Console.Write("Enter number of rows:(n)");
                n = int.Parse(Console.ReadLine());
                count = n - 1;
                for (j = 1; j <= n; j++)
                {
                    for (i = 1; i <= count; i++)
                        Console.Write(" ");
                    count--;
                    for (i = 1; i <= 2 * j - 1; i++)
                        Console.Write("*");
                    Console.WriteLine();
                }
                }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            try
            {
                int n2, i, s = 0;
                Console.Write("Enter a integer Number ");
                n2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("The odds number are:");
                for (i = 1; i <= n2; i++)
                {
                    Console.Write("{0} ", 2 * i - 1);
                    s = s + 2 * i - 1;
                }

                Console.Write("\nThe sum  is : {1} \n", n2, s);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                bool isInc = true;
                bool isDec = true;
                for (int i = 0; i < n.Length - 1; i++)
                {
                    if (n[i] > n[i + 1])
                    {
                        isInc = false;
                    }
                    if (n[i] < n[i + 1])
                    {
                        isDec = false;
                    }
                }
                return isDec || isInc;
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
                if (k < 0) return 0;

                var orderList = new Dictionary<int, int>(J.Length);
                foreach (var i in J)
                {
                    if (!orderList.ContainsKey(i))
                        orderList[i] = 0;
                    orderList[i]++;
                }

                if (k == 0)
                    return orderList.Count(i => i.Value > 1);

                var forReturn = 0;
                foreach (var orderItem in orderList)
                    if (orderList.ContainsKey(orderItem.Key + k))
                        forReturn++;

                return forReturn;
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
                    int index = 0;
                    foreach (char c in chars)
                    {
                        count += Math.Abs(keyboard.IndexOf(c) - index);
                        index = keyboard.IndexOf(c);
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
                int n = str1.Length;
                int m = str2.Length;
                //其中一个是空串
                if (n * m == 0)
                {
                    return n + m;
                }

                int[,] dp = new int[n + 1, m + 1];
                //A串为空，初始化边界
                for (int i = 0; i <= m; i++)
                {
                    dp[0, i] = i;
                }
                //B串为空，初始化边界
                for (int i = 0; i <= n; i++)
                {
                    dp[i, 0] = i;
                }

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {
                        //A串插入
                        int left = dp[i, j - 1] + 1;
                        //B串插入
                        int right = dp[i - 1, j] + 1;
                        //A串替换
                        int edit = dp[i - 1, j - 1];
                        if (str1[i - 1] != str2[j - 1])
                        {
                            edit++;
                        }
                        dp[i, j] = Math.Min(left, Math.Min(right, edit));
                    }
                }
                return dp[n, m];
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}
