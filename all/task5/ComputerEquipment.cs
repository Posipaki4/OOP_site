using System;

namespace Lab5
{
    public abstract class ComputerEquipment
    {
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public int WarrantyMonths { get; set; }
        public int ReleaseYear { get; set; }

        private int popularityRating;
        public int PopularityRating 
        { 
            get { return popularityRating; } 
            set { popularityRating = value < 1 ? 1 : (value > 10 ? 10 : value); } 
        }

        public ComputerEquipment(string modelName = "Unknown", decimal price = 0m, string manufacturer = "Unknown",
                                  int warrantyMonths = 12, int popularityRating = 5, int releaseYear = 0)
        {
            ModelName = modelName;
            Price = price;
            Manufacturer = manufacturer;
            WarrantyMonths = warrantyMonths;
            PopularityRating = popularityRating;
            ReleaseYear = releaseYear == 0 ? DateTime.Now.Year : releaseYear;
        }

        public ComputerEquipment(ComputerEquipment other)
        {
            ModelName = other.ModelName;
            Price = other.Price;
            Manufacturer = other.Manufacturer;
            WarrantyMonths = other.WarrantyMonths;
            PopularityRating = other.PopularityRating;
            ReleaseYear = other.ReleaseYear;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Модель: {ModelName}, Виробник: {Manufacturer}");
            Console.WriteLine($"\tЦіна: {Price} грн, Рейтинг: {PopularityRating}/10, Рік: {ReleaseYear}");
        }

        public virtual decimal CalculateOperatingCost(int months) { return months * 50m; }
        
        public virtual string DetermineBenefit() { return "Базові обчислювальні можливості."; }
        public virtual string DetermineHarm() { return "Потенційна втома при тривалому використанні."; }
    }

    public class Computer : ComputerEquipment
    {
        public int RamCapacity { get; set; }
        public int HddCapacity { get; set; }

        public Computer(string modelName = "Unknown", decimal price = 0m, string manufacturer = "Unknown",
                        int warrantyMonths = 12, int popularityRating = 5, int releaseYear = 0,
                        int ramCapacity = 8, int hddCapacity = 256)
            : base(modelName, price, manufacturer, warrantyMonths, popularityRating, releaseYear)
        {
            RamCapacity = ramCapacity;
            HddCapacity = hddCapacity;
        }

        public Computer(Computer other) : base(other)
        {
            RamCapacity = other.RamCapacity;
            HddCapacity = other.HddCapacity;
        }

        public new void Display()
        {
            Console.Write("[Комп'ютер] ");
            base.Display(); 
            Console.WriteLine($"\tRAM: {RamCapacity} GB, HDD: {HddCapacity} GB");
        }

        public sealed override string DetermineBenefit()
        {
            return "Швидкість пошуку інформації = економія часу.";
        }

        public static Computer operator ++(Computer c)
        {
            if (c.ReleaseYear >= DateTime.Now.Year - 2) c.PopularityRating++;
            return c;
        }

        public static Computer operator -(Computer c)
        {
            Computer result = new Computer(c);
            result.Price = c.Price * 0.9m;
            return result;
        }

        public static Computer operator +(Computer c1, Computer c2)
        {
            Computer result = new Computer(c1);
            result.ModelName = c1.ModelName + " + " + c2.ModelName;
            result.Price = c1.Price + c2.Price;
            result.PopularityRating = (c1.PopularityRating + c2.PopularityRating) / 2;
            return result;
        }
    }

    public class Monitor : ComputerEquipment
    {
        public double ScreenSize { get; set; }

        public Monitor(string modelName = "Unknown", decimal price = 0m, string manufacturer = "Unknown",
                       int warrantyMonths = 12, int popularityRating = 5, int releaseYear = 0, double screenSize = 24.0)
            : base(modelName, price, manufacturer, warrantyMonths, popularityRating, releaseYear)
        {
            ScreenSize = screenSize;
        }

        public override void Display()
        {
            Console.Write("[Монітор] ");
            base.Display();
            Console.WriteLine($"\tДіагональ: {ScreenSize}\"");
        }
    }

    public class Tablet : ComputerEquipment
    {
        public int BatteryCapacity { get; set; }

        public Tablet(string modelName = "Unknown", decimal price = 0m, string manufacturer = "Unknown",
                      int warrantyMonths = 12, int popularityRating = 5, int releaseYear = 0, int batteryCapacity = 5000)
            : base(modelName, price, manufacturer, warrantyMonths, popularityRating, releaseYear)
        {
            BatteryCapacity = batteryCapacity;
        }

        public Tablet(Tablet other) : base(other)
        {
            BatteryCapacity = other.BatteryCapacity;
        }

        public override void Display()
        {
            Console.Write("[Планшет] ");
            base.Display();
            Console.WriteLine($"\tБатарея: {BatteryCapacity} mAh");
        }
    }

    public class Printer : ComputerEquipment
    {
        public int PrintSpeed { get; set; }
        public bool IsColor { get; set; }

        public Printer(string modelName = "Unknown", decimal price = 0m, string manufacturer = "Unknown",
                       int warrantyMonths = 12, int popularityRating = 5, int releaseYear = 0,
                       int printSpeed = 20, bool isColor = false)
            : base(modelName, price, manufacturer, warrantyMonths, popularityRating, releaseYear)
        {
            PrintSpeed = printSpeed;
            IsColor = isColor;
        }

        public Printer(Printer other) : base(other)
        {
            PrintSpeed = other.PrintSpeed;
            IsColor = other.IsColor;
        }

        public override void Display()
        {
            Console.Write("[Принтер] ");
            base.Display();
            Console.WriteLine($"\tШвидкість: {PrintSpeed} стор/хв, Кольоровий: {(IsColor ? "Так" : "Ні")}");
        }
    }
}
