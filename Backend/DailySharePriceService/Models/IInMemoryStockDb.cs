using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePrice.Models
{
   public  interface IInMemoryStockDb
    {
        DailyStockDetails DailySharePrice(string StockName);
    }
}
