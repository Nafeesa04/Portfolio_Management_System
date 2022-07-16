using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculateNetWorthApi.Models;
using CalculateNetWorthApi.Provider;
using CalculateNetWorthApi.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace CalculateNetWorthApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class NetWorthController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetWorthController));

        private readonly INetWorthProvider _netWorthProvider;

        public NetWorthController(INetWorthProvider netWorthProvider)
        {
            _netWorthProvider = netWorthProvider;
        }

        [HttpPost]
        public IActionResult GetNetWorth(PortFolioDetails portFolioDetails)
        {

            NetWorth _netWorth = new NetWorth();
            _log4net.Info("Calculating the networth of user with id = " + portFolioDetails.PortFolioId + "In the method:" + nameof(GetNetWorth));

            try
            {
                if (portFolioDetails == null)
                {
                    return NotFound("The portfolio doesn't contain any data");
                }
                else if (portFolioDetails.PortFolioId == 0)
                {
                    return NotFound("The user with that id not found");
                }
                else
                {
                    _log4net.Info("The portfolio details are correct.Returning the networth of user with id" + portFolioDetails.PortFolioId);
                    _netWorth = _netWorthProvider.calculateNetWorthAsync(portFolioDetails).Result;
                    _log4net.Info("The networth is:" + JsonConvert.SerializeObject(_netWorth));
                    return Ok(_netWorth);
                }
            }
            catch (Exception ex)
            {
                _log4net.Info("An exception occured while calculating the networth:" + ex + " In the controller" + nameof(GetNetWorth));
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SellAssets(PortFolioDetails portFolioDetails)
        {
            try
            {
                AssetSaleResponse assetSaleResponse = new AssetSaleResponse();
                if (portFolioDetails == null)
                {
                    return NotFound("The portfolio doesn't contain any data");
                }
                else if (portFolioDetails.PortFolioId == 0)
                {
                    return NotFound("The user with that id not found");
                }
                else
                {

                    assetSaleResponse = _netWorthProvider.SellAsset(portFolioDetails);
                    if (assetSaleResponse == null)
                    {
                        _log4net.Info("Couldn't be sold because of invalid portfolio");
                        return NotFound("Please provide a valid list of portfolios");
                    }
                    _log4net.Info("The response is" + JsonConvert.SerializeObject(assetSaleResponse));
                    return Ok(assetSaleResponse);
                }
            }
            catch (Exception ex)
            {
                _log4net.Info("An exception occured while calculating the networth:" + ex + " In the controller" + nameof(SellAssets));
                return new StatusCodeResult(500);
            }

        }
    }
}
