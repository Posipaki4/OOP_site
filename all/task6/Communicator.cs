using System;

namespace Lab6
{
    public class Communicator
    {
        public void SendMessage(string targetName, string message)
        {
            Console.WriteLine($"[Відправлено до {targetName}]: {message}");
        }

        public void ReceiveMessage(string senderName, string message)
        {
            Console.WriteLine($"[Отримано від {senderName}]: {message}");
        }
    }
}
