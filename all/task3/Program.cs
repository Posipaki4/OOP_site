using System;
using System.Text;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Log.Init();
            Log.WriteLine("--- Лабораторна робота №3 ---");

            Client currentClient = new Client();
            Bank bank = new Bank("ПриватБанк", "305299", "PBANKUA", "privatbank.ua");
            Bank.Website website = new Bank.Website("privat24.ua", "Приват24");

            bool clientInitialized = false;

            while (true)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1. Створити/редагувати клієнта");
                Console.WriteLine("2. Регулювання курсу (НБУ)");
                Console.WriteLine("3. Емісія грошей (НБУ)");
                Console.WriteLine("4. Поповнити рахунок клієнта");
                Console.WriteLine("5. Витратити кошти (оплата/покупка)");
                Console.WriteLine("6. Взяти кредит");
                Console.WriteLine("7. Відкрити депозит");
                Console.WriteLine("8. Сайт банку: переказ коштів на інший рахунок");
                Console.WriteLine("9. Сайт банку: оплата комунальних послуг");
                Console.WriteLine("10. Вивести інформацію про клієнта та банк");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть дію: ");
                
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        currentClient.InputFromConsole();
                        clientInitialized = true;
                        currentClient.WriteToFile("Results.txt");
                        break;
                    case "2":
                        Console.WriteLine("1. Купити валюту (НБУ купує)");
                        Console.WriteLine("2. Продати валюту (НБУ продає)");
                        Console.Write("Оберіть дію: ");
                        string nbuAction = Console.ReadLine();
                        Console.Write("Введіть обсяг валюти ($): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal volume))
                        {
                            if (nbuAction == "1") NBU.RegulateCurrencyRate("Купівля", volume);
                            else if (nbuAction == "2") NBU.RegulateCurrencyRate("Продаж", volume);
                            else Console.WriteLine("Невірна дія!");
                        }
                        else
                            Console.WriteLine("Невірний формат обсягу!");
                        break;
                    case "3":
                        Console.Write("Введіть суму емісії (грн): ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal emitAmount))
                            NBU.EmitMoney(emitAmount);
                        else
                            Console.WriteLine("Невірний формат суми!");
                        break;
                    case "4":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Console.Write("Введіть суму поповнення: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal topUp))
                            currentClient.TopUpAccount(topUp);
                        else
                            Console.WriteLine("Невірний формат суми!");
                        break;
                    case "5":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Console.Write("Введіть суму для витрати: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal spend))
                            currentClient.DecreaseAccount(spend);
                        else
                            Console.WriteLine("Невірний формат суми!");
                        break;
                    case "6":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Console.Write("Введіть суму кредиту: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal creditAmount))
                        {
                            Console.Write("Введіть відсоткову ставку (%): ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal rate))
                                bank.IssueCredit(currentClient, creditAmount, rate);
                            else
                                Console.WriteLine("Невірний формат ставки.");
                        }
                        else Console.WriteLine("Невірний формат суми.");
                        break;
                    case "7":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Console.Write("Введіть суму депозиту: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depAmount))
                        {
                            Console.Write("Введіть річну ставку (%): ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depRate))
                            {
                                Console.Write("Введіть кількість місяців: ");
                                if (int.TryParse(Console.ReadLine(), out int months ))
                                    bank.AcceptDeposit(currentClient, depAmount, depRate, months);
                                else
                                    Console.WriteLine("Невірний формат місяців.");
                            }
                            else Console.WriteLine("Невірний формат ставки.");
                        }
                        else Console.WriteLine("Невірний формат суми.");
                        break;
                    case "8":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Client client2 = new Client("Іван", "Іванова", "АВ987654", "Львів", "0987654321", "+380671234567");
                        Console.Write("Введіть суму переказу Анні Івановій: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal transfer))
                            website.TransferFunds(currentClient, client2, transfer);
                        else
                            Console.WriteLine("Невірний формат суми.");
                        break;
                    case "9":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        Console.Write("Введіть суму для оплати комуналки: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal utility))
                            website.PayUtilityBills(currentClient, utility);
                        else
                            Console.WriteLine("Невірний формат суми.");
                        break;
                    case "10":
                        if (!clientInitialized) { Console.WriteLine("Спочатку створіть клієнта!"); break; }
                        currentClient.OutputToConsole();
                        bank.OutputToConsole();
                        website.CheckBalance(currentClient);
                        break;
                    case "0":
                        Log.WriteLine("Вихід з програми. Всі результати збережено у Results.txt.");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
