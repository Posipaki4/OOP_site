using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Розумний годинник - Лабораторна робота №6 ===");

            try
            {
                // Масив людей
                Person[] people = new Person[3];
                people[0] = new Person("Олександр", 25);
                people[1] = new Person("Марія", 22);
                people[2] = new Person("Іван", 30);

                // Присвоєння годинників
                people[0].Watch = new SmartVoiceAssistant(people[0]);
                people[1].Watch = new SmartWatch(people[1]);

                // Підписка на події розрядки батареї
                people[0].Watch.OnBatteryLow += (level) => Console.WriteLine($"\n[Увага] Батарея Олександра розряджається! Поточний рівень: {level}%");

                Console.WriteLine("\n--- Перевірка комунікації (зв'язок) ---");
                people[0].Communicate(people[1], "Привіт, як справи?");

                Console.WriteLine("\n--- Перевірка розумного голосового помічника ---");
                if (people[0].Watch is SmartVoiceAssistant assistant)
                {
                    assistant.ExecuteVoiceCommand("де я");
                }

                Console.WriteLine("\n--- Перевірка фітнес трекера (критичні ситуації) ---");
                // Нормальні показники
                Console.WriteLine("Оновлення нормальних показників...");
                people[0].Watch.UpdateVitals(75, 120, 80, 36.6);
                
                // Критичні показники, викличуть подію OnCriticalSituation
                Console.WriteLine("Оновлення критичних показників...");
                people[1].Watch.UpdateVitals(180, 190, 130, 39.8);

                Console.WriteLine("\n--- Обробка виключення виходу масиву за межі ---");
                try 
                {
                    people[3] = new Person("Помилка", 40);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Перехоплено виключення IndexOutOfRangeException: " + ex.Message);
                }

                Console.WriteLine("\n--- Тест розрядженої батареї ---");
                for (int i = 0; i < 90; i++)
                {
                    // Витрачає по 1% батареї на кожне оновлення (годинник Олександра має <= 95% батареї зараз)
                    people[0].Watch.UpdateVitals(75, 120, 80, 36.6); 
                }
            }
            catch (LowBatteryException ex)
            {
                Console.WriteLine("\nПерехоплено LowBatteryException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nЗагальна помилка: " + ex.Message);
            }

            Console.WriteLine("\nРоботу програми завершено. Натисніть Enter.");
            // Console.ReadLine();
        }
    }
}
