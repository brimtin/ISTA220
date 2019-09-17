using System;
using System.Collections.Generic;

namespace CalculatingAverage
{
    class Program
    {

        static void Main(string[] args)
        {
            int option = 0;
            //int size = 10;
            int[] testScores = new int[10];
            do
            {
                DisplayMenu();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        { 
                            Option1(testScores);
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Option2(testScores);
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("How many test scores do you want to you want to input? ");
                            int input = int.Parse(Console.ReadLine());
                            int[] grades = new int[input];
                            Option3(grades);
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            Option4();
                            Console.Clear();
                            break;
                        }
                    default:

                        Console.Clear();
                        break;
                }
            } while (option != 0);

        }

        static void DisplayMenu()
        {
            Console.WriteLine("Welcome To Calculating Averages and Test Scores!!!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Press 1 To get the sum of 10 numbers");
            Console.WriteLine("Press 2 To get the average of 10 numbers");
            Console.WriteLine("Press 3 To get the average of an abitrary number of test scores");
            Console.WriteLine("Press 4 To get the average of a non-specific set of numbers");
            Console.WriteLine("Press 0 To Exit the Program");
            Console.Write(".......");
        }

        static void DisplayAnArray(int[] a)
        {
            Console.Write("{");
            for (int i = 0; i < a.Length - 1; i++)
            {
                Console.Write($"{a[i]}, ");
            }
            Console.Write($"{a[a.Length - 1]}}}");
        }
        static void SetArrayValuesFromUser(int[] a)
        {
            for (int i = 0; i < a.Length;)
            {
                Console.Write($"{i}. Please enter a number between 0 and 100:..........");
                a[i] = int.Parse(Console.ReadLine());
                if (a[i] >= 0 && a[i] <= 100)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("\aInvalid Input!!!");
                }
            }
        }

        static int GetSumOfAnArray(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }

            return sum;
        }

        static double GetAverageOfAnArray(int[] a) => GetSumOfAnArray(a) / (a.Length);

        static Char Grade(int[] a)
        {
            if (GetAverageOfAnArray(a) < 60)
            {
                return 'F';
            }

            else if (GetAverageOfAnArray(a) < 70)
            {
                return 'D';
            }

            else if (GetAverageOfAnArray(a) < 80)
            {
                return 'C';
            }

            else if (GetAverageOfAnArray(a) < 90)
            {
                return 'B';
            }

            else
            {
                return 'A';
            }


        }

        static void Option1(int[] a)
        {
            SetArrayValuesFromUser(a);
            Console.WriteLine($"The sum of the following Numbers ");
            DisplayAnArray(a);
            Console.WriteLine($" is : {GetSumOfAnArray(a)}");
            Console.ReadLine();
        }

        static void Option2(int[] a)
        {
            SetArrayValuesFromUser(a);
            Console.WriteLine($"The average of the following Numbers ");
            DisplayAnArray(a);
            Console.WriteLine($" is : {GetAverageOfAnArray(a)}");
            Console.ReadLine();
        }

        static void Option3(int[] a)
        {
            SetArrayValuesFromUser(a);
            Console.WriteLine($"The average of the test scores entered: ");
            DisplayAnArray(a);
            Console.WriteLine($" is : {GetAverageOfAnArray(a)}");
            Console.WriteLine($"With an Average grade of {Grade(a)}");
            Console.ReadLine();
        }

        static void Option4()
        {
            List<int> testScores = new List<int>();
            int score = 0;
            bool isLastNumberEntered = false;

            do
            {
                Console.Write("Please enter a Test Score between 0 and 100:..........");
                string input = Console.ReadLine().ToUpper();
                if (input == "X")
                {
                    isLastNumberEntered = true;
                }
                else if (int.TryParse(input, out score) && score >= 0 && score <= 100)
                {
                    testScores.Add(score);
                }
                else
                {
                    Console.WriteLine("\aNot a Valid input");
                }


            } while (isLastNumberEntered == false);

            int[] a = testScores.ToArray();
            Console.WriteLine($"The average for all test score entered is : {GetAverageOfAnArray(a)}");
            Console.WriteLine($"The average grade for the class is        : {Grade(a)}");
            Console.ReadLine();
        }

    }
}
