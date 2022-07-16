using Microsoft.AspNetCore.Mvc;
using DailyMutualFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyMutualFund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMutualFundNavController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DailyMutualFundNavController));

        private IMutualFundDb MutualFundDbObj;

        public DailyMutualFundNavController(IMutualFundDb obj)
        {
            MutualFundDbObj = obj;
        }

        
        [HttpGet("{mutualFundName}")]
        public ActionResult Get(string mutualFundName)
        {
            _log4net.Info("Http Get request to fetch mutual fund details by mutualFundName");
            if (mutualFundName == null)
            {
                return BadRequest();
            }
            if (MutualFundDbObj.MutualFundNav(mutualFundName) == null)
            {
                return BadRequest();
            }


            return Ok(MutualFundDbObj.MutualFundNav(mutualFundName));
        }
        [HttpGet]
        public ActionResult GetAllMutualFunds()
        {
            _log4net.Info("Http Get request to fetch AllMutualFunds List");
            return Ok(MutualFundDb.mutualFundDetailList);
        }
    }
}
