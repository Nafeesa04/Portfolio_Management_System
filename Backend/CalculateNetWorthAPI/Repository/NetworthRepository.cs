using CalculateNetWorthApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CalculateNetWorthApi.Repository
{ 
    public class NetworthRepository : INetWorthRepository
    {

        private IConfiguration configuration;

        public NetworthRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(NetworthRepository));

        public static List<PortFolioDetails> _portFolioDetails = new List<PortFolioDetails>()
            {
                new PortFolioDetails{
                    PortFolioId=935287,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "SBI", MutualFundUnits=44},
                        new MutualFundDetails{MutualFundName = "HDFC", MutualFundUnits=66}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 19, StockName = "TATA"},
                        new StockDetails{StockCount = 667, StockName = "HDFC"}
                    }
                },
                new PortFolioDetails
                {
                    PortFolioId =934764,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "AXIS", MutualFundUnits=34},
                        new MutualFundDetails{MutualFundName = "CANARA", MutualFundUnits=566}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 240, StockName = "Hero"},
                        new StockDetails{StockCount = 46, StockName = "Bajaj"}
                    }
                },
                new PortFolioDetails
                {
                    PortFolioId = 935395,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "ICICI", MutualFundUnits=34},
                        new MutualFundDetails{MutualFundName = "BIRLA", MutualFundUnits=566}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 240, StockName = "Wipro"},
                        new StockDetails{StockCount = 46, StockName = "Havells"}
                    }
                },
                new PortFolioDetails
                {
                    PortFolioId = 934564,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "LIC", MutualFundUnits=34},
                        new MutualFundDetails{MutualFundName = "TATACAPITALS", MutualFundUnits=566}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 240, StockName = "PNB"},
                        new StockDetails{StockCount = 46, StockName = "SBI"}
                    }
                },
                new PortFolioDetails
                {
                    PortFolioId = 936056,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "NIPPON", MutualFundUnits=8},
                        new MutualFundDetails{MutualFundName = "KOTAK", MutualFundUnits=6},
                        new MutualFundDetails{MutualFundName = "LIC", MutualFundUnits=6}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 20, StockName = "TVS"},
                        new StockDetails{StockCount = 34, StockName = "Airtel"},
                        new StockDetails{StockCount = 12, StockName = "HDFC"}
                    }
                }


            };

        public async Task<NetWorth> calculateNetWorthAsync(PortFolioDetails portFolioDetails)
        {
            
            Stock stock = new Stock();
            MutualFund mutualfund = new MutualFund();
            NetWorth networth = new NetWorth();
            _log4net.Info("Calculating the networth in the repository method of user with id = "+portFolioDetails.PortFolioId);
            try
            {
                using (var httpClient = new HttpClient())
                {

                    var fetchStock = configuration["GetStockDetails"];
                    var fetchMutualFund = configuration["GetMutualFundDetails"];
                    if (portFolioDetails.StockList != null && portFolioDetails.StockList.Any() == true)
                    {
                        foreach (StockDetails stockDetails in portFolioDetails.StockList)
                        {
                            if (stockDetails.StockName != null)
                            {
                                using (var response = await httpClient.GetAsync(fetchStock + stockDetails.StockName))
                                {
                                    _log4net.Info("Fetching the details of stock "+stockDetails.StockName+"from the stock api");
                                    string apiResponse = await response.Content.ReadAsStringAsync();
                                    stock = JsonConvert.DeserializeObject<Stock>(apiResponse);
                                    _log4net.Info("Th stock details are " + JsonConvert.SerializeObject(stock));
                                }
                                networth.Networth += stockDetails.StockCount * stock.StockValue;
                            }
                        }
                    }
                    if (portFolioDetails.MutualFundList != null && portFolioDetails.MutualFundList.Any() == true)
                    {
                        foreach (MutualFundDetails mutualFundDetails in portFolioDetails.MutualFundList)
                        {
                            if (mutualFundDetails.MutualFundName != null)
                            {
                                using (var response = await httpClient.GetAsync(fetchMutualFund + mutualFundDetails.MutualFundName))
                                {
                                    _log4net.Info("Fetching the details of mutual Fund " + mutualFundDetails.MutualFundName + "from the MutualFundNAV api");
                                    string apiResponse = await response.Content.ReadAsStringAsync();
                                    mutualfund = JsonConvert.DeserializeObject<MutualFund>(apiResponse);
                                    _log4net.Info("The mutual Fund Details are" + JsonConvert.SerializeObject(mutualfund));
                                }
                                networth.Networth += mutualFundDetails.MutualFundUnits * mutualfund.MutualFundValue;
                            }
                        }
                    }
                }
                networth.Networth = Math.Round(networth.Networth, 2);
            }
            catch(Exception ex)
            {
                _log4net.Error("Exception occured while calculating the networth of user"+portFolioDetails.PortFolioId+":"+ex.Message);
            }
            return networth;
        }
    }
}
