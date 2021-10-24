using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollateralForLoans.Controllers;
using CollateralForLoans.Models;

namespace CollateralForLoans
{
    class FacilityController : BaseController<Facility>, IBaseController<Facility>
    {
        private List<Covenant> CovenantsList;

        public FacilityController(string path, List<Covenant> covenants)
        {
            CovenantsList = covenants;

            GetModelFromFile(path);
        }

        public void GetModelFromFile(string path)
        {
            string[] csvLines = System.IO.File.ReadAllLines(path);

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(",");

                Facility facility = new(Convert.ToInt32(data[2]), Convert.ToDouble(data[0]), Convert.ToDouble(data[1]), Convert.ToDouble(data[3]));

                Collection.Add(facility);
            }
        }

        public Facility CheckMatch(Loan loan)
        {
            List<Facility> compare = new();

            foreach(Facility facility in Collection)
            {
                if (facility.FreeAmount < loan.Amount) continue;
                else if (CheckRestrictions(facility, loan)) continue;

                compare.Add(facility);
            }

            return compare[0];
        }

        private bool CheckRestrictions(Facility facility, Loan loan)
        {
            Covenant maxDefault = CovenantsList.Find(e => e.FacilityId == facility.Id && e.MaxDefaultLikelihood != null);

            List<Covenant> data = CovenantsList.FindAll(e => e.FacilityId == facility.Id && e.BannedState == loan.State && maxDefault.MaxDefaultLikelihood < loan.DefaultLikelihood);

            return data.Count > 0;
        }
    }
}
