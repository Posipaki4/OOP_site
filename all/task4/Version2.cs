using System;

namespace Lab4.Version2
{
    public interface IComputerEquipment
    {
        void Display();
        decimal CalculateCost();
        int DeterminePopularityRating(int positiveReviews);
    }

    public class ComputerEquipment : IComputerEquipment
    {
        private string modelName;
        private decimal price;
        private string manufacturer;
        private int warrantyMonths;

        public string ModelName { get { return modelName; } set { modelName = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
        public int WarrantyMonths { get { return warrantyMonths; } set { warrantyMonths = value; } }

        public ComputerEquipment(string modelName, decimal price, string manufacturer, int warrantyMonths)
        {
            this.modelName = modelName;
            this.price = price;
            this.manufacturer = manufacturer;
            this.warrantyMonths = warrantyMonths;
        }

        public virtual void Display()
        {
            Console.WriteLine($"[Version 2 - Interface] Model: {modelName}, Price: {price}, Manufacturer: {manufacturer}, Warranty: {warrantyMonths} months");
        }

        public virtual decimal CalculateCost()
        {
            return price;
        }
        
        public virtual int DeterminePopularityRating(int positiveReviews)
        {
            return positiveReviews > 100 ? 5 : (positiveReviews > 50 ? 4 : 3);
        }
    }

    public class Computer : ComputerEquipment
    {
        private int ramCapacity;
        private int hddCapacity;

        public Computer(string modelName, decimal price, string manufacturer, int warrantyMonths, int ramCapacity, int hddCapacity)
            : base(modelName, price, manufacturer, warrantyMonths)
        {
            this.ramCapacity = ramCapacity;
            this.hddCapacity = hddCapacity;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\tRAM: {ramCapacity}GB, HDD: {hddCapacity}GB");
        }
    }

    public class Monitor : ComputerEquipment
    {
        private double screenSize;

        public Monitor(string modelName, decimal price, string manufacturer, int warrantyMonths, double screenSize)
            : base(modelName, price, manufacturer, warrantyMonths)
        {
            this.screenSize = screenSize;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\tScreen Size: {screenSize} inches");
        }
    }

    public class Tablet : ComputerEquipment
    {
        private int batteryCapacity;

        public Tablet(string modelName, decimal price, string manufacturer, int warrantyMonths, int batteryCapacity)
            : base(modelName, price, manufacturer, warrantyMonths)
        {
            this.batteryCapacity = batteryCapacity;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\tBattery: {batteryCapacity} mAh");
        }
    }
}
