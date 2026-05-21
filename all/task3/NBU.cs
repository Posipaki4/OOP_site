using System;

namespace BankSystem
{
    public static class NBU
    {
        public static decimal ExchangeRate { get; private set; } = 40.0m;

        public static void RegulateCurrencyRate(string action, decimal volume)
        {
            decimal change = volume * 0.01m;

            if (action == "Купівля")
            {
                ExchangeRate += change; 
                Log.WriteLine($"НБУ купив {volume}$ на міжбанку. Долар виріс. Поточний курс: {ExchangeRate:F2} грн/дол.");
            }
            else if (action == "Продаж")
            {
                ExchangeRate -= change;
                if (ExchangeRate < 1.0m) ExchangeRate = 1.0m; 
                Log.WriteLine($"НБУ продав {volume}$ на міжбанку. Долар впав. Поточний курс: {ExchangeRate:F2} грн/дол.");
            }
        }

        public static void EmitMoney(decimal amount)
        {
            decimal change = amount * 0.001m;
            ExchangeRate += change;
            
            Log.WriteLine($"НБУ надрукував {amount} грн (емісія). Долар виріс. Поточний курс: {ExchangeRate:F2} грн/дол.");
        }
    }
}
