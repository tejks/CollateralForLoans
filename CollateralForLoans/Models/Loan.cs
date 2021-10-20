using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans.Models
{
    class Loan
    {
        public int Id { get; }
        public double InterestRate { get; }
        public int Amount { get; }
        public double DefaultLikelihood { get; }
        public string State { get; }

        public Loan(int id, double interestRate, int amount, double defaultLikelihood, string state)
        {
            Id = id;
            InterestRate = interestRate;
            Amount = amount;
            DefaultLikelihood = defaultLikelihood;
            State = state;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Interest: {InterestRate}, Amount: {Amount}, DefaultLikelihood: {DefaultLikelihood}, State: {State}";
        }
    }
}
