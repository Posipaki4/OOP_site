using System;
using System.IO;

namespace BankSystem
{
    public class Client
    {
        private string firstName;
        private string lastName;
        private string passport;
        private string address;
        private string idCode;
        private string phone;
        private decimal balance;

        public Client()
        {
            firstName = ""; lastName = ""; passport = ""; address = ""; idCode = ""; phone = ""; balance = 0;
        }

        public Client(string fName, string lName, string pass, string addr, string id, string ph)
        {
            firstName = fName; lastName = lName; passport = pass; address = addr; idCode = id; phone = ph; balance = 0;
        }

        public string FirstName { get { return firstName; } set { firstName = string.IsNullOrWhiteSpace(value) ? "Невідомо" : value; } }
        public string LastName { get { return lastName; } set { lastName = string.IsNullOrWhiteSpace(value) ? "Невідомо" : value; } }
        public string Passport { get { return passport; } set { passport = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string IdCode { get { return idCode; } set { idCode = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public decimal Balance { get { return balance; } set { balance = value >= 0 ? value : 0; } }

        public void InputFromConsole()
        {
            Console.Write("Введіть ім'я: "); FirstName = Console.ReadLine();
            Console.Write("Введіть прізвище: "); LastName = Console.ReadLine();
            Console.Write("Введіть паспорт: "); Passport = Console.ReadLine();
            Console.Write("Введіть адресу: "); Address = Console.ReadLine();
            Console.Write("Введіть інд. код: "); IdCode = Console.ReadLine();
            Console.Write("Введіть телефон: "); Phone = Console.ReadLine();
            Log.WriteLine($"Клієнта {FirstName} {LastName} створено/оновлено.");
        }

        public void OutputToConsole()
        {
            Log.WriteLine($"Клієнт: {firstName} {lastName}, Паспорт: {passport}, Баланс: {balance} грн");
        }

        public void WriteToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine($"Клієнт: {firstName} {lastName}, Паспорт: {passport}, Баланс: {balance} грн");
            }
        }

        public void DecreaseAccount(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Log.WriteLine($"Знято {amount} грн. Поточний баланс: {balance} грн.");
            }
            else
            {
                Log.WriteLine("Недостатньо коштів на рахунку!");
            }
        }

        public void TopUpAccount(decimal amount)
        {
            balance += amount;
            Log.WriteLine($"Рахунок поповнено на {amount} грн. Поточний баланс: {balance} грн.");
        }
    }
}
