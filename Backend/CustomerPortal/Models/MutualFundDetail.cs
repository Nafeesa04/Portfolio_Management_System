using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortalMVC.Models
{
    public class MutualFundDetail
    {
        public int TMutualId { get; set; }
        public int PortfolioId { get; set; }
        public string MutualFundName { get; set; }
        public int MutualFundCount { get; set; }
        public int TotalPrice { get; set; }
        public bool saleStatus { get; set; }

    }
}
