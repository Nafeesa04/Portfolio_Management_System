using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Authorization.Models
{
    public class PortfolioDetailContext:DbContext
    {
        public PortfolioDetailContext(DbContextOptions<PortfolioDetailContext>options):base(options)
        {

        }
        public DbSet<PortfolioDetail> PortfolioDetails { get; set; }
    }
}
