using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFund.Models
{
    public class MutualFundDb : IMutualFundDb
    {
        public static List<DailyMutualFundNav> mutualFundDetailList = new List<DailyMutualFundNav> {
            new DailyMutualFundNav { MutualFundId=1,MutualFundName="Vanguard",MutualFundValue=100},
            new DailyMutualFundNav { MutualFundId = 2, MutualFundName = "Fidelity", MutualFundValue = 200 },
            new DailyMutualFundNav { MutualFundId = 3, MutualFundName = "ICICI", MutualFundValue = 300 },
            new DailyMutualFundNav { MutualFundId = 4, MutualFundName = "Axis", MutualFundValue = 400 },
            new DailyMutualFundNav { MutualFundId = 5, MutualFundName = "BARODA", MutualFundValue = 500 }
            };

        public DailyMutualFundNav MutualFundNav(string mutualFundName)
        {
            return mutualFundDetailList.FirstOrDefault(c => c.MutualFundName.ToLower() == mutualFundName.ToLower());

        }
    }
}
