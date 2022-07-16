using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerPortalMVC.Models
{
    public class PortfolioDetail
    {
        public int PortfolioId { get; set; }
        public string CustomerName { get; set; }
        [EmailAddress,Required]
        public string Email { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
