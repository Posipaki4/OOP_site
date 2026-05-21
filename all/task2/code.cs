using System;

namespace Lab2
{
    class Program
    {
        static int[] globalArray;
        static int[,] globalMatrix;

        static void PrintArray(int[] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            foreach (int item in arr) Console.Write(item + " ");
            Console.WriteLine();
        }

        static void Task1()
        {
            Console.Write("Enter number of array elements ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter number of array elements ");
            }

            if (n <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0");
                return;
            }

            Console.Write("Enter minimum value ");
            int min;
            while (!int.TryParse(Console.ReadLine(), out min))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter minimum value ");
            }

            Console.Write("Enter maximum value ");
            int max;
            while (!int.TryParse(Console.ReadLine(), out max))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter maximum value ");
            }

            globalArray = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++) globalArray[i] = rnd.Next(min, max + 1);

            Console.WriteLine("Generated array");
            PrintArray(globalArray);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (globalArray[j] > globalArray[j + 1])
                    {
                        int temp = globalArray[j];
                        globalArray[j] = globalArray[j + 1];
                        globalArray[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted array");
            PrintArray(globalArray);
        }

        static void Task2()
        {
            if (globalArray == null || globalArray.Length == 0)
            {
                Console.WriteLine("Please complete Task 1 first");
                return;
            }

            int maxVal = 0;
            foreach (int val in globalArray)
            {
                if (val > maxVal) maxVal = val;
            }

            if (maxVal < 2)
            {
                Console.WriteLine("No prime numbers in the array");
                return;
            }

            int k = (maxVal - 1) / 2;
            bool[] marked = new bool[k + 1];
            for (int i = 1; i <= k; i++)
                for (int j = i; (i + j + 2 * i * j) <= k; j++)
                    marked[i + j + 2 * i * j] = true;

            List<int> primes = new List<int>();
            if (maxVal >= 2) primes.Add(2);
            for (int i = 1; i <= k; i++)
            {
                if (!marked[i])
                {
                    int prime = 2 * i + 1;
                    if (prime <= maxVal) primes.Add(prime);
                }
            }

            bool found = false;
            Console.WriteLine("Prime numbers in the array");
            foreach (int val in globalArray)
            {
                if (primes.Contains(val))
                {
                    Console.Write(val + " ");
                    found = true;
                }
            }
            Console.WriteLine();
            if (!found) Console.WriteLine("Prime numbers not found");
        }

        static void Task3()
        {
            if (globalArray == null || globalArray.Length == 0)
            {
                Console.WriteLine("Please complete Task 1 first");
                return;
            }

            int maxEvenIdx = -1, minOddIdx = -1;
            int maxEvenVal = int.MinValue, minOddVal = int.MaxValue;

            for (int i = 0; i < globalArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (globalArray[i] > maxEvenVal)
                    {
                        maxEvenVal = globalArray[i];
                        maxEvenIdx = i;
                    }
                }
                else
                {
                    if (globalArray[i] < minOddVal)
                    {
                        minOddVal = globalArray[i];
                        minOddIdx = i;
                    }
                }
            }

            if (maxEvenIdx != -1) Console.WriteLine($"Max element with even index {maxEvenVal} at index {maxEvenIdx}");
            if (minOddIdx != -1) Console.WriteLine($"Min element with odd index {minOddVal} at index {minOddIdx}");

            if (maxEvenIdx != -1 && minOddIdx != -1)
            {
                int temp = globalArray[maxEvenIdx];
                globalArray[maxEvenIdx] = globalArray[minOddIdx];
                globalArray[minOddIdx] = temp;
                Console.WriteLine("Array after swap");
                PrintArray(globalArray);
            }
        }

        static void Task4()
        {
            if (globalArray == null || globalArray.Length == 0)
            {
                Console.WriteLine("Please complete Task 1 first");
                return;
            }

            int maxVal = 0;
            foreach (int val in globalArray)
            {
                if (val > maxVal) maxVal = val;
            }

            List<int> fibs = new List<int>();
            int f1 = 1, f2 = 1;
            fibs.Add(f1);
            fibs.Add(f2);
            while (true)
            {
                int next = f1 + f2;
                if (next > maxVal) break;
                fibs.Add(next);
                f1 = f2;
                f2 = next;
            }

            bool found = false;
            Console.WriteLine("Fibonacci numbers in the array");
            for (int i = 0; i < globalArray.Length; i++)
            {
                if (fibs.Contains(globalArray[i]))
                {
                    Console.WriteLine($"Element {globalArray[i]} Index {i}");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Fibonacci numbers not found");
        }

        static void Task5()
        {
            if (globalArray == null || globalArray.Length == 0)
            {
                Console.WriteLine("Please complete Task 1 first");
                return;
            }

            int maxVal = 0;
            foreach (int val in globalArray)
            {
                if (val > maxVal) maxVal = val;
            }

            List<int> ctn = new List<int>();
            int n = 1;
            while (true)
            {
                int t = (3 * n * n + 3 * n + 2) / 2;
                if (t > maxVal && t > 0) break;
                ctn.Add(t);
                n++;
            }

            bool found = false;
            Console.WriteLine("Centered triangular numbers in the array");
            int[] sortedArray = (int[])globalArray.Clone();
            Array.Sort(sortedArray);

            foreach (int t in ctn)
            {
                int index = Array.BinarySearch(sortedArray, t);
                if (index >= 0)
                {
                    for (int i = 0; i < globalArray.Length; i++)
                    {
                        if (globalArray[i] == t)
                        {
                            Console.WriteLine($"Element {t} Index {i}");
                            found = true;
                        }
                    }
                }
            }
            if (!found) Console.WriteLine("Centered triangular numbers not found");
        }

        static void Task6()
        {
            Console.Write("Enter number of students rows ");
            int rows;
            while (!int.TryParse(Console.ReadLine(), out rows))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter number of students rows ");
            }

            Console.Write("Enter number of disciplines columns ");
            int cols;
            while (!int.TryParse(Console.ReadLine(), out cols))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter number of disciplines columns ");
            }

            if (rows <= 0 || cols <= 0)
            {
                Console.WriteLine("Dimensions must be greater than 0");
                return;
            }

            globalMatrix = new int[rows, cols];
            Random rnd = new Random();
            Console.WriteLine("Lab work matrix");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    globalMatrix[i, j] = rnd.Next(0, 16);
                    Console.Write(globalMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int maxLabs = -1;
            List<int> topStudents = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++) sum += globalMatrix[i, j];
                if (sum > maxLabs)
                {
                    maxLabs = sum;
                    topStudents.Clear();
                    topStudents.Add(i);
                }
                else if (sum == maxLabs)
                {
                    topStudents.Add(i);
                }
            }
            Console.WriteLine($"Students with max lab works {maxLabs} are " + string.Join(" ", topStudents));

            int minLabs = int.MaxValue;
            List<int> minDisciplines = new List<int>();
            for (int j = 0; j < cols; j++)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++) sum += globalMatrix[i, j];
                if (sum < minLabs)
                {
                    minLabs = sum;
                    minDisciplines.Clear();
                    minDisciplines.Add(j);
                }
                else if (sum == minLabs)
                {
                    minDisciplines.Add(j);
                }
            }
            Console.WriteLine($"Disciplines with min lab works {minLabs} are " + string.Join(" ", minDisciplines));

            List<int> zeroLabStudents = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (globalMatrix[i, j] == 0)
                    {
                        zeroLabStudents.Add(i);
                        break;
                    }
                }
            }
            string zeroStuds = zeroLabStudents.Count > 0 ? string.Join(" ", zeroLabStudents) : "none";
            Console.WriteLine("Students with 0 works in at least one discipline " + zeroStuds);
        }

        static void Task7()
        {
            if (globalMatrix == null)
            {
                Console.WriteLine("Please complete Task 6 first");
                return;
            }
            int rows = globalMatrix.GetLength(0);
            int cols = globalMatrix.GetLength(1);

            List<int> rowsToKeep = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (globalMatrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero) rowsToKeep.Add(i);
            }

            if (rowsToKeep.Count == rows)
            {
                Console.WriteLine("No students with 0 works Matrix unchanged");
                return;
            }
            if (rowsToKeep.Count == 0)
            {
                Console.WriteLine("All students have at least one 0 Matrix is empty");
                globalMatrix = new int[0, 0];
                return;
            }

            int[,] newMatrix = new int[rowsToKeep.Count, cols];
            for (int i = 0; i < rowsToKeep.Count; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = globalMatrix[rowsToKeep[i], j];
                }
            }

            globalMatrix = newMatrix;
            Console.WriteLine("Transformed matrix");
            for (int i = 0; i < globalMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < globalMatrix.GetLength(1); j++)
                {
                    Console.Write(globalMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static double f(double x)
        {
            return 2 * Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 12 * x + 8;
        }

        static void Task8()
        {
            Console.WriteLine("Equation 2x^3 - 3x^2 - 12x + 8 = 0");
            
            Console.Write("Enter left boundary ");
            double left;
            while (!double.TryParse(Console.ReadLine(), out left))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter left boundary ");
            }

            Console.Write("Enter right boundary ");
            double right;
            while (!double.TryParse(Console.ReadLine(), out right))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter right boundary ");
            }

            Console.Write("Enter precision ");
            double eps;
            while (!double.TryParse(Console.ReadLine(), out eps))
            {
                Console.WriteLine("Input error");
                Console.Write("Enter precision ");
            }

            if (f(left) * f(right) > 0)
            {
                Console.WriteLine("Function does not change sign on this interval");
                return;
            }

            double center = 0;
            while (right - left > eps * 2)
            {
                center = left + (right - left) / 2;
                if (f(center) * f(left) > 0)
                {
                    left = center;
                }
                else
                {
                    right = center;
                }
            }
            Console.WriteLine($"Found root {center}");
            Console.WriteLine($"Check f({center}) = {f(center)}");
        }

        static void Task9()
        {
            Console.WriteLine("Enter character string");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("String is empty");
                return;
            }

            string[] words = input.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> filteredWords = new List<string>();
            int countSameFirstLast = 0;

            foreach (string word in words)
            {
                if (word.Length > 1)
                {
                    filteredWords.Add(word);
                    if (char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
                    {
                        countSameFirstLast++;
                    }
                }
            }

            Console.WriteLine("String after removing single letter words");
            Console.WriteLine(string.Join(" ", filteredWords));
            if (countSameFirstLast > 0)
            {
                Console.WriteLine($"Words where first and last letters are same {countSameFirstLast}");
            }
            else
            {
                Console.WriteLine("No words found where first and last letters are same");
            }
        }
    
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1 Task 1 (Array generation and sorting)");
                Console.WriteLine("2 Task 2 (Prime numbers - Sieve of Sundaram)");
                Console.WriteLine("3 Task 3 (Max/Min by indices and swap)");
                Console.WriteLine("4 Task 4 (Fibonacci numbers)");
                Console.WriteLine("5 Task 5 (Centered triangular numbers - Binary search)");
                Console.WriteLine("6 Task 6 (Matrix students and disciplines)");
                Console.WriteLine("7 Task 7 (Deleting rows from matrix)");
                Console.WriteLine("8 Task 8 (Bisection method)");
                Console.WriteLine("9 Task 9 (String processing)");
                Console.WriteLine("0 Exit");
                Console.Write("Choose task ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Input error");
                    Console.Write("Choose task ");
                }

                switch (choice)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    case 5: Task5(); break;
                    case 6: Task6(); break;
                    case 7: Task7(); break;
                    case 8: Task8(); break;
                    case 9: Task9(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
