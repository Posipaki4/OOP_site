using System;

namespace Lab6
{
    public class SmartWatchException : ApplicationException
    {
        public SmartWatchException() { }
        public SmartWatchException(string message) : base(message) { }
        
        public override string Message
        {
            get
            {
                return $"Помилка годинника: {base.Message}";
            }
        }
    }

    public class LowBatteryException : SmartWatchException
    {
        public LowBatteryException(string message) : base(message) { }
    }
}
