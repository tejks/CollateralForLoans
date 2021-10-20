using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollateralForLoans.Controllers;
using CollateralForLoans.Models;

namespace CollateralForLoans
{
    class LoanController : BaseController<Loan>, IBaseController<Loan>
    {
        public LoanController(string path)
        {
            GetModelFromFile(path);
        }

        public void GetModelFromFile(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Loan loan = new(Convert.ToInt32(data[2]), Convert.ToDouble(data[0]), Convert.ToInt32(data[1]), Convert.ToDouble(data[3]), data[4]);

                Collection.Add(loan);
            }
        }
    }
}
