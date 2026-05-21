using System;

namespace BankSystem
{
    public partial class Bank
    {
        public void AcceptDeposit(Client client, decimal depositAmount, decimal interestRate, int months)
        {
            client.DecreaseAccount(depositAmount);
            decimal profit = depositAmount * (1 + (interestRate / 12) * months / 100);
            Log.WriteLine($"Депозит оформлено. Очікуваний прибуток через {months} місяців: {profit} грн.");
        }
    }
}
