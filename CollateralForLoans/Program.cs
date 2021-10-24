using System;
using System.Collections.Generic;
using CollateralForLoans.Models;
using System.Text;

namespace CollateralForLoans
{
    class Program
    {
        static void Main(string[] args)
        {
            CovenantController covenants = new(path: @"A:\zadanie\large\covenants.csv");

            FacilityController facilities = new(path: @"A:\zadanie\large\facilities.csv", covenants.Collection);

            LoanController loans = new(path: @"A:\zadanie\large\loans.csv");

            List<string> result = new();

            foreach (Loan loan in loans.Collection)
            {
                Facility facility = facilities.CheckMatch(loan);

                facility.FreeAmount -= loan.Amount;

                double facilityCost = CalcFacilityCost(facility);
                double loanCost = CalcLoanCost(loan);

                result.Add($"{loan.Id},{facility.Id},{Convert.ToString(facilityCost)},{Convert.ToString(loanCost)},{Convert.ToString(Math.Round(loanCost + facilityCost, 2))}");
            }

            SaveToFile(result);
        }

        static double CalcFacilityCost(Facility facility)
        {
            return Math.Round(facility.Amount * facility.InterestRate, 2);
        }

        static double CalcLoanCost(Loan loan)
        {
            return Math.Round(loan.Amount * loan.InterestRate, 2);
        }

        static void SaveToFile(List<string> result)
        {
            var csv = new StringBuilder();

            csv.AppendLine("loan_id,facility_id,loan_cost,facility_cost,full_cost");

            foreach(string line in result)
            {
                csv.AppendLine(line);
            }

            System.IO.File.WriteAllText(@".\result.csv", csv.ToString());
        }
    }
}
