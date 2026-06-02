using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №5 ===");

            Console.WriteLine("\n--- 1. Демонстрація конструкторів ---");
            Printer defaultPrinter = new Printer();
            Printer paramPrinter = new Printer("Epson L3150", 6000, "Epson", 24, 8, 2023, 33, true);
            Printer copyPrinter = new Printer(paramPrinter);

            defaultPrinter.Display();
            paramPrinter.Display();
            copyPrinter.Display();

            Console.WriteLine("\n--- 2. Віртуальні методи, приховування (new) та base ---");
            Computer comp = new Computer("Dell XPS", 40000, "Dell", 36, 9, 2024, 32, 1024);
            Monitor mon = new Monitor("LG UltraGear", 12000, "LG", 24, 7, 2022, 27.0);
            
            comp.Display(); 
            mon.Display();

            Console.WriteLine("\n--- 3. Перевантаження унарних операторів (++, -) ---");
            Computer modernComp = new Computer("MacBook M3", 60000, "Apple", 12, 8, 2025, 16, 512);
            modernComp++; 
            modernComp = -modernComp; 
            modernComp.Display();

            Console.WriteLine("\n--- 4. Перевантаження бінарних операторів (+) ---");
            Computer oldComp = new Computer("Old PC", 5000, "NoName", 0, 5, 2015, 4, 128);
            Computer combo = modernComp + oldComp;
            Console.WriteLine($"Сумарна ціна modernComp + oldComp: {combo.Price:C}");

            Console.WriteLine("\n--- 5. Масив об'єктів з індексатором ---");
            ComputerCollection collection = new ComputerCollection(2);
            collection[0] = comp;
            collection[1] = mon;
            collection.DisplayAll();
            
            Console.ReadLine();
        }
    }
}
