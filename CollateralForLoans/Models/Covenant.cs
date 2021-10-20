using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollateralForLoans.Models
{
    class Covenant
    {
        public int FacilityId { get; }
        public dynamic MaxDefaultLikelihood { get; }
        public int BankId { get; }
        public string BannedState { get; }

        public Covenant(int facilityId, dynamic maxDefaultLikelihood, int bankId, string bannedState)
        {
            FacilityId = facilityId;
            MaxDefaultLikelihood = maxDefaultLikelihood;
            BankId = bankId;
            BannedState = bannedState;
        }

        public override string ToString()
        {
            return $"FacilityId: {FacilityId}, MaxDefaultLikelihood: {MaxDefaultLikelihood}, BankId: {BankId}, BannedState: {BannedState}";
        }
    }
}
