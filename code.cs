using System;

namespace task1_1
{
    class Program
    {
        static void task1_1()
        {
            double a = 3, b = 2, c = 6, d = 1;
            int x;
            Console.WriteLine("Name: Pastukh Sebastian\nAge: 17\nCourse: IPZ-14\nEmail: pas.sebas@knu.ua ");
            System.Console.WriteLine("Write down x to find polinom: p = a*x^4 - b*x^3 + c^x + d");
            Console.Write("Enter x: ");
            
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Error! Enter an integer for x: ");
            }

            Console.WriteLine("Result p = " + (a * x * x * x * x - b * x * x * x + c * x + d));
        }

        static void task1_2()
        {
            int a, b, c, d;
            Console.WriteLine("Input a, b, c, d for equation x = (a+b)^2/sqrt(sinc-cosd)");
            
            Console.Write("Enter a: ");
            while (!int.TryParse(Console.ReadLine(), out a)) Console.Write("Error! Enter an integer for a: ");
            
            Console.Write("Enter b: ");
            while (!int.TryParse(Console.ReadLine(), out b)) Console.Write("Error! Enter an integer for b: ");
            
            Console.Write("Enter c: ");
            while (!int.TryParse(Console.ReadLine(), out c)) Console.Write("Error! Enter an integer for c: ");
            
            Console.Write("Enter d: ");
            while (!int.TryParse(Console.ReadLine(), out d)) Console.Write("Error! Enter an integer for d: ");

            Console.WriteLine("x = " + (Math.Pow((a + b), 2) / Math.Sqrt(Math.Sin(c) - Math.Cos(d))));
        }

        static void task1_3()
        {
            System.Console.WriteLine("Calculate the value of the function at point x...");
            System.Console.WriteLine("       {4x-1. , x>0");
            System.Console.WriteLine("f(x) = {25x+10, x<0");
            System.Console.WriteLine("       {0.    , x=0");
            System.Console.Write("Enter x: ");
            
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Enter a number: ");
            }

            if (x > 0)
            {
                System.Console.WriteLine("Answer for x = " + x + ": " + (4 * x - 1));
            }
            else if (x < 0)
            {
                System.Console.WriteLine("Answer for x = " + x + ": " + (25 * x + 10));
            }
            else
            {
                System.Console.WriteLine("Answer for x = " + x + ": 0");
            }
        }

        static void task1_4()
        {
            string[] array = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            System.Console.Write("Enter the number of day: ");
            
            int day;
            while (!int.TryParse(Console.ReadLine(), out day))
            {
                Console.Write("Error! Enter an integer for the day: ");
            }

            if (0 < day && day < 8)
            {
                System.Console.WriteLine("The " + day + " is " + array[day - 1]);
            }
            else
            {
                System.Console.WriteLine("There is no such day of the week.");
            }
        }

        static void task1_5()
        {
            const int MIN_num = 1;
            const int MAX_num = 25;
            int sum = 0, num = 0;
            
            Console.WriteLine("Enter numbers between " + MIN_num + " and " + MAX_num + " to sum (any non-integer to stop):");
            
            while (int.TryParse(Console.ReadLine(), out num))
            {
                if (MIN_num < num && num < MAX_num)
                {
                    sum += num;
                }
                else
                {
                    System.Console.WriteLine("Error: number is out of limit");
                }
                System.Console.WriteLine("Current sum is: " + sum);
                System.Console.Write("Next number: ");
            }
            System.Console.WriteLine("Final sum is: " + sum);
        }

        static void Main(string[] args)
        {
            bool flag = true;
            int index1 = 0;
            
            while (flag)
            {
                System.Console.WriteLine("\nChoose task to do (0 - to exit):");
                System.Console.WriteLine("1. Output information about author and find polinom");
                System.Console.WriteLine("2. Find value of expression");
                System.Console.WriteLine("3. Calculate the value of the function at point x");
                System.Console.WriteLine("4. Get week from number");
                System.Console.WriteLine("5. Calculate the sum of numbers in a given range");
                System.Console.WriteLine("0. Exit");

                while (!int.TryParse(Console.ReadLine(), out index1))
                {
                    System.Console.WriteLine("Error, write an integer!!");
                }

                switch (index1)
                {
                    case 1: task1_1(); break;
                    case 2: task1_2(); break;
                    case 3: task1_3(); break;
                    case 4: task1_4(); break;
                    case 5: task1_5(); break;
                    case 0: flag = false; break;
                    default: System.Console.WriteLine("Choose a task from 0 to 5."); break;
                }
            }
        }
    }
}
