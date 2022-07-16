using CalculateNetWorthApi.Models;
using CalculateNetWorthApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetWorthApi.Provider
{
    public class NetWorthProvider : INetWorthProvider
    {
        private readonly INetWorthRepository _netWorthRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetWorthProvider));

        public NetWorthProvider(INetWorthRepository netWorthRepository)
        {
            _netWorthRepository = netWorthRepository;
        }

        public Task<NetWorth> calculateNetWorthAsync(PortFolioDetails portFolioDetails)
        {
            NetWorth networth = new NetWorth();
            try
            {
                _log4net.Info("Provider called from Controller to calculate the networth");
                if (portFolioDetails.PortFolioId==0)
                {
                    return null;
                }
                networth = _netWorthRepository.calculateNetWorthAsync(portFolioDetails).Result;
            }
            catch(Exception ex)
            {
                _log4net.Error("Exception occured while calculating the networth"+ex.Message);
            }
            return Task.FromResult(networth);


        }


        public AssetSaleResponse SellAsset(PortFolioDetails portfolioDetails)
        {

            NetWorth _networth = new NetWorth();
            AssetSaleResponse assetSaleResponse = null;


            bool saleStatus = false;

            if (portfolioDetails.AssetTypeToBeSold == "Stock")
            {
                StockDetails stockToBeSold = portfolioDetails.StockList.FirstOrDefault(x => x.StockName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());

                saleStatus = portfolioDetails.StockList.Remove(stockToBeSold);
            }
            else
            {

                MutualFundDetails mutualFundToBeSold = portfolioDetails.MutualFundList.FirstOrDefault(x => x.MutualFundName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());

                saleStatus = portfolioDetails.MutualFundList.Remove(mutualFundToBeSold);
            }
            _networth = _netWorthRepository.calculateNetWorthAsync(portfolioDetails).Result;

            assetSaleResponse = new AssetSaleResponse()
            {
                SaleStatus = saleStatus,
                Networth = _networth.Networth
            };
            return assetSaleResponse;
        }
    }
}
