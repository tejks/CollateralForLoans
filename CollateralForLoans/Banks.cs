using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans
{
    class Banks
    {
        private readonly List<Bank> BanksList = new();

        public void genereteModelByPath(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for(int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Bank bank = new(Convert.ToInt32(data[0]), data[1]);

                BanksList.Add(bank);
            }
        }

        public void getAllBanks()
        {
            foreach (Bank bank in BanksList)
            {
                Console.WriteLine(bank.ToString());
            }
        }
    }

    class Bank
    {
        public int Id { get; }
        public string Name { get; }

        public Bank(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
