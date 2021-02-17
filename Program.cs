using System;

namespace Parking_problem
{

    public abstract class GarageFees
    {
        public int minimumFee = 2;
        public double additionalHours = 0.5;
        public int maxFee = 10;
        public static double total = 0;
    }

    public class Customer : GarageFees
    {
        public int Hours = 0;
        public double charges = 0;
        public bool isChargesCalculated = false;

        public Customer(int hours)
        {
            Hours = hours;
        }

        public double CalculateCharges()
        {
            if (isChargesCalculated == false)
            {
                if (Hours > 3)
                {
                    charges = minimumFee;
                    int count = Hours - 3;
                    while (count > 0)
                    {
                        if (charges != maxFee)
                        {
                            charges += 0.5;
                        }
                        count--;
                    }
                    isChargesCalculated = true;
                    total += charges;
                }
                else
                {
                    charges = minimumFee;
                    isChargesCalculated = true;
                    total += charges;
                }
            }

            return charges;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer cust1 = new Customer(2);
            Console.WriteLine($"The charges of the customer number 1 are {cust1.CalculateCharges()} euros.\n");

            Customer cust2 = new Customer(3);
            Console.WriteLine($"The charges of the customer number 2 are {cust2.CalculateCharges()} euros.\n");

            Customer cust3 = new Customer(10);
            Console.WriteLine($"The charges of the customer number 3 are {cust3.CalculateCharges()} euros.\n");

            Customer cust4 = new Customer(23);
            Console.WriteLine($"The charges of the customer number 4 are {cust4.CalculateCharges()} euros.\n");


            Console.WriteLine($"The running total of yesterday’s receipts is {GarageFees.total} euros.");
        }
    }
}
