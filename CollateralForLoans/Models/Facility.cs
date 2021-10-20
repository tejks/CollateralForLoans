using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans.Models
{
    class Facility
    {
        public int Id { get; }
        public double Amount { get; }
        public double InterestRate { get; }
        public double BankId { get; }
        public double FreeAmount { get; set; }

        public Facility(int id, double amount, double interestRate, double bankId)
        {
            Id = id;
            Amount = amount;
            InterestRate = interestRate;
            BankId = bankId;
            FreeAmount = amount;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Amount: {Amount}, InterestRate: {InterestRate}, BankId: {BankId}";
        }
    }
}
