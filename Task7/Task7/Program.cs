namespace Task7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private const int RndMax = 100;
        private const int RndMin = -100;
        private const int ArrayLength = 10;
        private const int TestArrayLength = 100000000;
        private const string RepeatString = "0";

        internal delegate bool Condition(int num);

        internal delegate void Task();

        public static void Main(string[] args)
        {
            Dictionary<int, Task> tasks = new Dictionary<int, Task>
            {
                { 1, SubTask1 },
                { 2, SubTask2 },
                { 3, SubTask3 }
            };

            bool repeat = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t{0}", Res.Task7);
                Console.WriteLine("1) {0}", Res.SubTask1Descr);
                Console.WriteLine("2) {0}", Res.SubTask2Descr);
                Console.WriteLine("3) {0}", Res.SubTask3Descr);
                Console.Write(Res.ToContinue);

                int taskNumber = default(int);
                int.TryParse(Console.ReadLine(), out taskNumber);
                if (tasks.ContainsKey(taskNumber))
                {
                    tasks[taskNumber].Invoke();
                }
                else
                {
                    Console.WriteLine(Res.WrongInput);
                }

                Console.Write(Res.RepeatMessage, RepeatString);
                repeat = Console.ReadLine() == RepeatString;
            }
            while (repeat);
        }

        internal static int Sum(this int[] arr)
        {
            int sum = default(int);
            foreach (int num in arr)
            {
                sum += num;
            }

            return sum;
        }

        internal static void Fill(this int[] arr, int rndMin = RndMin, int rndMax = RndMax)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(rndMin, rndMax);
            }
        }

        internal static void Print<T>(this T[] arr)
        {
            foreach (T obj in arr)
            {
                Console.Write("{0}, ", obj.ToString());
            }

            Console.WriteLine();
        }

        internal static bool IsInt(this string str)
        {
            foreach (char ch in str)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return str != string.Empty;
        }

        internal static bool IsPositive(int num)
        {
            return num >= 0;
        }

        internal static int[] AllPositive(int[] arr)
        {
            int[] arrToReturn = new int[0];

            foreach (int num in arr)
            {
                if (num >= 0)
                {
                    arrToReturn.Append(num);
                }
            }

            return arrToReturn;
        }

        internal static int[] AllPositive(int[] arr, Condition condition)
        {
            int[] arrToReturn = new int[0];

            foreach (int num in arr)
            {
                if (condition(num))
                {
                    arrToReturn.Append(num);
                }
            }

            return arrToReturn;
        }

        internal static void SubTask1()
        {
            int[] arr = new int[ArrayLength];
            arr.Fill();
            arr.Print();
            Console.WriteLine(arr.Sum());
        }

        internal static void SubTask2()
        {
            Console.Write(Res.InputPositiveInteger);
            bool isInt = Console.ReadLine().IsInt();
            Console.WriteLine(isInt);
        }

        internal static void SubTask3()
        {
            Console.WriteLine("{0}{1}", Res.FindPositiveTest, TestArrayLength);

            int[] arr = new int[TestArrayLength];
            arr.Fill();

            var before = DateTime.Now;
            int[] positiveArr = AllPositive(arr);
            Console.WriteLine("{0}: {1}", Res.Method, (DateTime.Now - before).ToString());
            positiveArr = null;

            before = DateTime.Now;
            Condition condition = IsPositive;
            int[] positiveArrDelegate = AllPositive(arr, condition);
            Console.WriteLine("{0}: {1}", Res.Delegate, (DateTime.Now - before).ToString());
            positiveArrDelegate = null;

            before = DateTime.Now;
            Condition conditionAnonym = delegate(int num)
            {
                return num >= 0;
            };
            int[] positiveArrDelegateAnonym = AllPositive(arr, conditionAnonym);
            Console.WriteLine("{0}: {1}", Res.Anonym, (DateTime.Now - before).ToString());
            positiveArrDelegateAnonym = null;

            before = DateTime.Now;
            Condition conditionLambda = num => num >= 0;
            int[] positiveArrDelegateLambda = AllPositive(arr, conditionLambda);
            Console.WriteLine("{0}: {1}", Res.Lambda, (DateTime.Now - before).ToString());
            positiveArrDelegateLambda = null;

            before = DateTime.Now;
            int[] positiveArrLINQ = arr.Where(x => x >= 0).ToArray();
            Console.WriteLine("{0}: {1}", Res.LINQ, (DateTime.Now - before).ToString());
            positiveArrLINQ = null;
        }
    }
}