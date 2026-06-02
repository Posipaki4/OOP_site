using System;

namespace Lab6
{
    // Спадкування
    public class SmartVoiceAssistant : SmartWatch
    {
        public SmartVoiceAssistant(Person owner) : base(owner)
        {
        }

        public void ExecuteVoiceCommand(string command)
        {
            UseBattery(3);
            Console.WriteLine($"\nГолосовий помічник почув команду: '{command}'");
            
            if (command.Contains("подзвони"))
            {
                Console.WriteLine("Виконую голосовий виклик...");
            }
            else if (command.Contains("де я"))
            {
                Console.WriteLine($"Ваші координати: {gps.GetLocation()}");
            }
            else
            {
                Console.WriteLine("Команда не розпізнана.");
            }
        }
    }
}
