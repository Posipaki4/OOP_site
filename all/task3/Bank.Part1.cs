using System;
using System.IO;

namespace BankSystem
{
    public partial class Bank
    {
        private string name;
        private string mfo;
        private string swift;
        private string websiteUrl;

        public Bank()
        {
            name = ""; mfo = ""; swift = ""; websiteUrl = "";
        }

        public Bank(string n, string m, string s, string w)
        {
            name = n; mfo = m; swift = s; websiteUrl = w;
        }

        public string Name { get { return name; } set { name = value; } }
        public string MFO { get { return mfo; } set { mfo = value; } }
        public string SWIFT { get { return swift; } set { swift = value; } }
        public string WebsiteUrl { get { return websiteUrl; } set { websiteUrl = value; } }

        public void OutputToConsole()
        {
            Log.WriteLine($"Банк: {name}, МФО: {mfo}, SWIFT: {swift}");
        }

        public void WriteToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine($"Банк: {name}, МФО: {mfo}, SWIFT: {swift}");
            }
        }

        public void IssueCredit(Client client, decimal amount, decimal interestRate)
        {
            decimal totalToPay = amount + (amount * interestRate / 100);
            client.TopUpAccount(amount);
            Log.WriteLine($"Кредит видано клієнту {client.LastName}. Сума до повернення з відсотками: {totalToPay} грн.");
        }

        public void OpenAccount(Client client, decimal fee)
        {
            client.DecreaseAccount(fee);
            Log.WriteLine($"Банк '{this.Name}' відкрив рахунок. Отримана комісія: {fee} грн.");
        }

        public class Website
        {
            public string URL;
            public string InternetBankName;

            public Website(string url, string name)
            {
                URL = url;
                InternetBankName = name;
            }

            public void CheckBalance(Client c)
            {
                Log.WriteLine($"[Web {InternetBankName}] Баланс клієнта {c.LastName}: {c.Balance} грн");
            }

            public void PayUtilityBills(Client c, decimal amount)
            {
                Log.WriteLine($"[Web {InternetBankName}] Оплата комунальних послуг...");
                c.DecreaseAccount(amount);
            }

            public void TransferFunds(Client from, Client to, decimal amount)
            {
                Log.WriteLine($"[Web {InternetBankName}] Переказ коштів від {from.LastName} до {to.LastName}...");
                from.DecreaseAccount(amount);
                to.TopUpAccount(amount);
            }
        }
    }
}
