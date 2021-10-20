using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollateralForLoans.Controllers;
using CollateralForLoans.Models;

namespace CollateralForLoans
{
    class BankController : BaseController<Bank>, IBaseController<Bank>
    {
        public void GetModelFromFile(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for(int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Bank bank = new(Convert.ToInt32(data[0]), data[1]);

                Collection.Add(bank);
            }
        }
    }
}
