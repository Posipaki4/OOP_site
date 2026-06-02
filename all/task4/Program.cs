
using System;
using Lab4.Version1;
using Lab4.Version2;
using Lab4.Version3;
using Lab4.Version4;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Версія 1: Звичайне успадкування ===");
            var v1Comp = new Lab4.Version1.Computer("Dell Inspiron", 15000, "Dell", 12, 16, 512);
            v1Comp.Display();
            Console.WriteLine($"Popularity: {v1Comp.DeterminePopularityRating(120)}");
            Console.WriteLine($"Cost with modifications: {v1Comp.CalculateCost()}");
            
            var v1Monitor = new Lab4.Version1.Monitor("LG UltraGear", 8000, "LG", 24, 27);
            v1Monitor.Display();

            Console.WriteLine("\n=== Версія 2: Інтерфейси ===");
            Lab4.Version2.IComputerEquipment v2Equipment1 = new Lab4.Version2.Computer("MacBook Pro", 45000, "Apple", 12, 16, 512);
            Lab4.Version2.IComputerEquipment v2Equipment2 = new Lab4.Version2.Tablet("iPad Air", 25000, "Apple", 12, 7000);
            
            v2Equipment1.Display();
            v2Equipment2.Display();

            Console.WriteLine("\n=== Версія 3: Абстрактні класи ===");
            Lab4.Version3.ComputerEquipment v3Equipment = new Lab4.Version3.Monitor("Samsung Odyssey", 12000, "Samsung", 24, 32);
            v3Equipment.Display();

            Console.WriteLine("\n=== Версія 4: Масив об'єктів класу Комп'ютер (IComparable, IComparer, IEnumerable) ===");
            ComputerCollection collection = new ComputerCollection();
            collection.Add(new Lab4.Version4.Computer("PC-1", 12000, 15.5));
            collection.Add(new Lab4.Version4.Computer("PC-2", 35000, 12.0));
            collection.Add(new Lab4.Version4.Computer("PC-3", 8000, 18.2));
            collection.Add(new Lab4.Version4.Computer("PC-4", 21000, 14.8));

            Console.WriteLine("--- Виведення комп'ютерів, відсортованих за ціною (IComparable, IEnumerable) ---");
            foreach (var comp in collection)
            {
                comp.Display();
            }

            Console.WriteLine("\n--- Виведення комп'ютерів, відсортованих за габаритами (IComparer) ---");
            var compList = new System.Collections.Generic.List<Lab4.Version4.Computer>
            {
                new Lab4.Version4.Computer("PC-1", 12000, 15.5),
                new Lab4.Version4.Computer("PC-2", 35000, 12.0),
                new Lab4.Version4.Computer("PC-3", 8000, 18.2)
            };
            
            compList.Sort(new Lab4.Version4.ComputerDimensionsComparer());
            foreach (var comp in compList)
            {
                comp.Display();
            }
        }
    }
}

