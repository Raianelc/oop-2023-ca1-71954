using System;
using oop_2023_ca1_71954.models;
using System.Collections.Generic;
using Bogus;


namespace oop_2023_ca1_71854
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Faker faker = new Faker();

            // Define the garages
            Garage garage1 = new Garage("Garage 1", 0.50);
            Garage garage2 = new Garage("Garage 2", 0.60);
            Garage garage3 = new Garage("Garage 3", 0.75);

            // Generate customers and parked hours
            List<Customer> customers = new List<Customer>();
            int totalReceipts = 0;

            for (int i = 0; i < 8; i++) // Generate 10 customers for example
            {
                string registration = faker.Vehicle.Vin();
                int parkedHours = random.Next(1, 24); // Random hours 

                Customer customer = new Customer(registration, parkedHours);
                customers.Add(customer);

                int charge = CalculateCharges(garage1, garage2, garage3, customer);
                totalReceipts += charge;

                Console.WriteLine($"Customer {customer.Registration} parked for {customer.ParkedHours} hours. Charge: €{charge:F2}");
            }

            // total for each garage
            Console.WriteLine($"\nTotal for {garage1.Name}: €{garage1.TotalReceipts:F2}");
            Console.WriteLine($"Total for {garage2.Name}: €{garage2.TotalReceipts:F2}");
            Console.WriteLine($"Total for {garage3.Name}: €{garage3.TotalReceipts:F2}");
            Console.WriteLine($"Total Garages Receipts: €{totalReceipts:F2}");
        }

        static int CalculateCharges(Garage garage1, Garage garage2, Garage garage3, Customer customer)
        {
            int charge = 2; // Minimum fee for up to three hours

            switch (customer.Registration[2] % 3)
            {
                case 0:
                    charge += garage1.CalculateAddCharge(customer.ParkedHours);
                    garage1.TotalReceipts += charge;
                    break;
                case 1:
                    charge += garage2.CalculateAddCharge(customer.ParkedHours);
                    garage2.TotalReceipts += charge;
                    break;
                case 2:
                    charge += garage3.CalculateAddCharge(customer.ParkedHours);
                    garage3.TotalReceipts += charge;
                    break;
            }


            return Math.Min(charge, 10);
        }
    }
}