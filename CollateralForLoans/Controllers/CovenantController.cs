using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollateralForLoans.Controllers;
using CollateralForLoans.Models;

namespace CollateralForLoans 
{
    class CovenantController : BaseController<Covenant>, IBaseController<Covenant>
    {
        public CovenantController(string path)
        {
            GetModelFromFile(path);
        }

        public void GetModelFromFile(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Covenant covenant = new(Convert.ToInt32(data[0]),  data[1] != "" ? Convert.ToDouble(data[1]) : null, Convert.ToInt32(data[2]), data[3]);

                Collection.Add(covenant);
            }
        }
    }
}
