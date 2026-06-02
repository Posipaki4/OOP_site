using System;
using System.Collections; 
using System.Collections.Generic;

namespace Lab4.Version4
{
    public class Computer : IComparable, IComparable<Computer>
    {
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public double Dimensions { get; set; }

        public Computer(string modelName, decimal price, double dimensions)
        {
            ModelName = modelName;
            Price = price;
            Dimensions = dimensions;
        }

        public void Display()
        {
            Console.WriteLine($"Computer Model: {ModelName}, Price: {Price}, Dimensions: {Dimensions}");
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            Computer? otherComputer = obj as Computer;
            if (otherComputer != null) 
                return this.Price.CompareTo(otherComputer.Price);
            else
                throw new ArgumentException("Object is not a Computer");
        }

        public int CompareTo(Computer? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }

    public class ComputerDimensionsComparer : IComparer<Computer>
    {
        public int Compare(Computer? x, Computer? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            
            return x.Dimensions.CompareTo(y.Dimensions);
        }
    }

    public class ComputerCollection : IEnumerable<Computer>
    {
        private List<Computer> computers = new List<Computer>();

        public void Add(Computer computer)
        {
            computers.Add(computer);
        }

        public IEnumerator<Computer> GetEnumerator()
        {
            computers.Sort();
            return computers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}