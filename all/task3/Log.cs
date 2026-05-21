using System;

namespace BankSystem
{
    internal static class Log
    {
        private static readonly string Path = "Results.txt";

        public static void Init()
        {
            File.WriteAllText(Path, "=== РЕЗУЛЬТАТИ ОПЕРАЦІЙ ===\n\n");
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
            File.AppendAllText(Path, text + "\n");
        }

        public static void Write(string text)
        {
            Console.Write(text);
            File.AppendAllText(Path, text);
        }
    }
}
