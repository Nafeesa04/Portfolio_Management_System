using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFund.Models
{
   public interface IMutualFundDb
    {
        DailyMutualFundNav MutualFundNav(string mutualFundName);
    }
}
