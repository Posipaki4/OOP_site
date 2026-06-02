using System;

namespace Lab6
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public SmartWatch Watch { get; set; } // Асоціація

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Communicate(Person other, string message)
        {
            Watch?.SendSignal(other, message);
        }
    }
}
