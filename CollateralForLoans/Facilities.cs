using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans
{
    class Facilities
    {
        private readonly List<Facility> FacilitiesList = new();

        public void genereteModelByPath(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Facility bank = new(Convert.ToInt32(data[2]), Convert.ToDouble(data[0]), Convert.ToDouble(data[1]), Convert.ToDouble(data[3]));

                FacilitiesList.Add(bank);
            }
        }

        public void getAllFacilities()
        {
            foreach (Facility facility in FacilitiesList)
            {
                Console.WriteLine(facility.ToString());
            }
        }
    }

    class Facility
    {
        public int Id { get; }
        public double Amount { get; }
        public double InterestRate { get; }
        public double BankId { get; }

        public Facility(int id, double amount, double interestRate, double bankId)
        {
            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            BankId = bankId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Amount: {Amount}, InterestRate: {InterestRate}, BankId: {BankId}";
        }
    }
}
