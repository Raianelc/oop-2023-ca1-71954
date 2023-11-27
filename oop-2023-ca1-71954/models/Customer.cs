using System;
namespace oop_2023_ca1_71954.models
{
    class Customer
    {
        public string Registration { get; }
        public int ParkedHours { get; }

        public Customer(string registration, int parkedHours)
        {
            Registration = registration;
            ParkedHours = parkedHours;
        }
    }
}
