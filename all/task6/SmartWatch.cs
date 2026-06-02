using System;
using System.IO;

namespace Lab6
{
    public delegate void BatteryLowHandler(int level);

    public class SmartWatch
    {
        // Композиція - SmartWatch створює свої компоненти і управляє їх життєвим циклом
        protected GpsTracker gps;
        protected FitnessTracker fitness;
        protected Communicator communicator;

        private int batteryLevel;

        public event BatteryLowHandler OnBatteryLow;

        public Person Owner { get; set; } // Агрегація

        public SmartWatch(Person owner)
        {
            Owner = owner;
            gps = new GpsTracker();
            fitness = new FitnessTracker();
            communicator = new Communicator();
            batteryLevel = 100;

            // Підписка на події компонентів
            fitness.OnCriticalSituation += HandleCriticalSituation;
        }

        public void UseBattery(int amount)
        {
            batteryLevel -= amount;
            if (batteryLevel <= 0)
            {
                batteryLevel = 0;
                throw new LowBatteryException("Батарея повністю розряджена!");
            }
            else if (batteryLevel < 20)
            {
                OnBatteryLow?.Invoke(batteryLevel);
            }
        }

        private void HandleCriticalSituation(string message)
        {
            Console.WriteLine($"\n🚨 УВАГА! Сигнал тривоги для {Owner.Name}: {message}");
            try 
            {
                File.AppendAllText("medical_log.txt", $"{DateTime.Now}: {Owner.Name} - {message}\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Помилка запису у файл журналу: " + ex.Message);
            }
        }

        public void SendSignal(Person other, string message)
        {
            UseBattery(2);
            communicator.SendMessage(other.Name, message);
            other.Watch?.ReceiveSignal(Owner.Name, message);
        }

        public void ReceiveSignal(string sender, string message)
        {
            communicator.ReceiveMessage(sender, message);
        }

        public void UpdateVitals(int pulse, int sys, int dia, double temp)
        {
            UseBattery(1);
            fitness.MeasureVitals(pulse, sys, dia, temp);
        }
    }
}
