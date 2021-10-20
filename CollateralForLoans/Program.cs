﻿using System;
using System.Collections.Generic;
using CollateralForLoans.Models;
using System.Text;

namespace CollateralForLoans
{
    class Program
    {
        static void Main(string[] args)
        {
            CovenantController covenants = new(path: @".\Resources\covenants.csv");

            FacilitieController facilities = new(path: @".\Resources\facilities.csv", covenants.Collection);

            LoanController loans = new(path: @".\Resources\loans.csv");

            List<string> result = new();

            foreach (Loan loan in loans.Collection)
            {
                Facility facility = facilities.CheckMatch(loan);

                facility.FreeAmount -= loan.Amount;

                double facilityCost = CalcFacilityCost(facility);
                double loanCost = CalcLoanCost(loan);

                result.Add($"{loan.Id},{facility.Id},{Convert.ToString(facilityCost)},{Convert.ToString(loanCost)},{Convert.ToString(loanCost + facilityCost)}");
            }

            SaveToFile(result);
        }

        static double CalcFacilityCost(Facility facility)
        {
            return facility.Amount * facility.InterestRate;
        }

        static double CalcLoanCost(Loan loan)
        {
            return loan.Amount * loan.InterestRate;
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
