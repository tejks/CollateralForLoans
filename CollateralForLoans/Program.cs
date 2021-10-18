using System;

namespace CollateralForLoans
{
    class Program
    {
        static void Main(string[] args)
        {
            Banks banks = new();

            banks.genereteModelByPath(@"C:\Users\szymo\Desktop\zadanie\zadanie\small\banks.csv");

            banks.getAllBanks();

            Facilities facilities = new();

            facilities.genereteModelByPath(@"C:\Users\szymo\Desktop\zadanie\zadanie\small\facilities.csv");

            facilities.getAllFacilities();
        }
    }
}
