using System;
using System.Data.Common;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
namespace task1_1
{
    class Program
    {
        static void task1_1()
        {
            int a = 3, b = 2,c = 6, d = 1;
            int x = 0;
            Console.WriteLine("Name: Pastukh Sebastian\nAge: 17\nCourse: IPZ-14\nEmail: pas.sebas@knu.ua ");
            System.Console.WriteLine("Write down x to find polinom: p = a*x^4 - b*x^3 + c^x + d");
            Console.Write("Enter x: ");
            bool Try1 = int.TryParse(Console.ReadLine(), out x);
            
            Console.WriteLine("Result p = " + (a*x*x*x*x-b*x*x*x+c*x+d));

        }
        static void task1_2()
        {
            Console.WriteLine("Input a, b, c, d for equation x = (a+b)^2/sqrt(sinc-cosd)");
            Console.Write("Enter a: ");
            bool Try1 = int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Enter b: ");
            bool Try2 = int.TryParse(Console.ReadLine(), out int b);
            Console.Write("Enter c: ");
            bool Try3 = int.TryParse(Console.ReadLine(), out int c);
            Console.Write("Enter d: ");
            bool Try4 = int.TryParse(Console.ReadLine(), out int d);
            Console.WriteLine("x = "+ (Math.Pow((a+b), 2)/Math.Sqrt(Math.Sin(c)-Math.Cos(d))));
        }
        static void task1_3()
        {   
            System.Console.WriteLine("Calculate the value of the function at point x, the value of which is entered from the console. If the input is not a number, display the corresponding message - Enter a number");
            System.Console.WriteLine("       {4x-1. , x>0");
            System.Console.WriteLine("f(x) = {25x+10, x<0");
            System.Console.WriteLine("       {0.    , x=0");
            System.Console.Write("Enter x: ");
            bool Try1 = int.TryParse(Console.ReadLine(), out int x);
            if(x > 0)
            {
                System.Console.WriteLine("Answer for x = "+ x + ": " + (4*x-1));
            }else if (x < 0)
            {
                System.Console.WriteLine("Answer for x = "+ x + ": " + (25*x+10));
            }else
            {
                System.Console.WriteLine("Answer for x = "+ x + ": 0");
            }

        }
        static void task1_4()
        {
            string[] array = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            System.Console.Write("Enter the number of day: ");
            bool Try1 = int.TryParse(Console.ReadLine(), out int day);
            if(0<day && day<8)
            {
            System.Console.WriteLine("The "+ day + " is " + array[day-1]);
            }
        }
        static void task1_5()
        {
            const int MAX_num = 25;
            const int MIN_num = 1;
            int sum = 0, num = 0;
            bool Try1 = true;
            while (Try1)
            {
            System.Console.Write("Enter numbers beetwen " + MIN_num + " and "+ MAX_num + " to sum: ");
            Try1 = int.TryParse(Console.ReadLine(), out num);
                if(MIN_num < num && num < MAX_num)
                {
                    sum += num;
                }
                else
                {
                    System.Console.WriteLine("Error number is out of limit");
                }

                System.Console.WriteLine("Current sum is: "+ sum);
            }
            System.Console.WriteLine("Final sum is: "+ sum);
            
        }
        static void Main(string[] args)
        {
            bool flag = true;
            int index1 = 0;
            bool Try = true;
            while(flag)
            {
                System.Console.WriteLine("Choose task to do(to exit write down any number not from list)\n1.Output information about author and find polinom\n2.Find value of expression\n3.Calculate the value of the function at point x\n4.Get week from number\n5.Calculate the sum of numbers in a given range");
                Try = int.TryParse(Console.ReadLine(), out index1);
                if(Try)
                {

                    switch(index1) {
                        case 1: task1_1(); break;
                        case 2: task1_2(); break;
                        case 3: task1_3(); break; 
                        case 4: task1_4(); break;
                        case 5: task1_5(); break;
                        default: flag = false; break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Error,  write an integer!!");
                }

            }
        }
    }
}
