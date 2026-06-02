using System;

namespace Lab6
{
    // Делегат для події критичної ситуації зі здоров'ям
    public delegate void HealthCriticalHandler(string message);

    public class FitnessTracker
    {
        public event HealthCriticalHandler OnCriticalSituation;

        private int pulse;
        private int bloodPressureSystolic;
        private int bloodPressureDiastolic;
        private int steps;
        private double temperature;

        public FitnessTracker()
        {
            pulse = 70;
            bloodPressureSystolic = 120;
            bloodPressureDiastolic = 80;
            steps = 0;
            temperature = 36.6;
        }

        public void MeasureVitals(int p, int bps, int bpd, double temp)
        {
            pulse = p;
            bloodPressureSystolic = bps;
            bloodPressureDiastolic = bpd;
            temperature = temp;

            CheckCritical();
        }

        public void AddSteps(int s)
        {
            if (s < 0) throw new ArgumentOutOfRangeException("Steps cannot be negative");
            steps += s;
        }

        private void CheckCritical()
        {
            if (pulse > 150 || pulse < 40)
            {
                OnCriticalSituation?.Invoke("Критичний пульс! Можливі проблеми із серцем (інфаркт).");
            }
            if (bloodPressureSystolic > 180 || bloodPressureDiastolic > 120)
            {
                OnCriticalSituation?.Invoke("Критичний артеріальний тиск! Можливий інсульт.");
            }
            if (temperature > 39.5)
            {
                OnCriticalSituation?.Invoke("Висока температура тіла! Гарячка.");
            }
        }
    }
}
