using DailySharePrice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailySharePrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailySharePriceController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DailySharePriceController));
        private readonly IInMemoryStockDb stockDbObj;

        public DailySharePriceController(IInMemoryStockDb obj)
        {
            stockDbObj = obj;
        }

        // GET: api/<DailySharePriceController>
        [HttpGet("{stockName}")]
        public ActionResult Get(string stockName)
        {
            _log4net.Info("Http Get request to fetch stock details by stockName");
            if (stockName == null)
            {
                return BadRequest();
            }
            var obj = stockDbObj.DailySharePrice(stockName);
            if (obj == null)
            {
                return BadRequest();
            }  
          return Ok(obj);
        }
        [HttpGet]
        public ActionResult GetAllStocks()
        {
            _log4net.Info("Http Get request to Get All Stocks List");
            return Ok(InMemoryStockDb.dailyStockDetails);

        }

        
        
    }
}
