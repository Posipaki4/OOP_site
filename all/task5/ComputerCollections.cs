using System;

namespace Lab5
{
    public class ComputerCollection
    {
        private ComputerEquipment[] data;
        
        public ComputerCollection(int size)
        {
            data = new ComputerEquipment[size];
        }

        public ComputerEquipment this[int index]
        {
            get
            {
                if (index < 0 || index >= data.Length) throw new IndexOutOfRangeException("Індекс поза межами масиву");
                return data[index];
            }
            set
            {
                if (index < 0 || index >= data.Length) throw new IndexOutOfRangeException("Індекс поза межами масиву");
                data[index] = value;
            }
        }

        public int Length { get { return data.Length; } }

        public void DisplayAll()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null) data[i].Display();
            }
        }
    }
}
