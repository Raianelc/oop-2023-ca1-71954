using System;
namespace oop_2023_ca1_71954.models
{
    class Garage
    {
        public string Name { get; }
        public double HourRate { get; }
        public int TotalReceipts { get; set; }

        public Garage(string name, double hourlyRate)
        {
            Name = name;
            HourRate = hourlyRate;
            TotalReceipts = 0;
        }

        public int CalculateAddCharge(int parkedHours)
        {
            return Math.Max(0, (parkedHours - 3)) * (int)(HourRate * 100);
        }
    }
}

