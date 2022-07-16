using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DailyMutualFundNAVMicroservice.Models;
using DailyMutualFundNAVMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DailyMutualFundNAVMicroservice.Repository
{
    public class MutualFundRepository:IMutualFundRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MutualFundRepository));
        private static List<MutualFundDetails> listOfFunds = new List<MutualFundDetails>()
        { 
            new MutualFundDetails { MutualFundId = 1001, MutualFundName = "SBI", MutualFundValue = 135.84},
            new MutualFundDetails { MutualFundId = 1002, MutualFundName = "HDFC", MutualFundValue = 100.16},
            new MutualFundDetails { MutualFundId = 1003, MutualFundName = "AXIS", MutualFundValue = 104.11},
            new MutualFundDetails { MutualFundId = 1004, MutualFundName = "CANARA", MutualFundValue = 175.84},
            new MutualFundDetails { MutualFundId = 1005, MutualFundName = "ICICI", MutualFundValue = 200.24},
            new MutualFundDetails { MutualFundId = 1006, MutualFundName = "BIRLA", MutualFundValue = 600.19},
            new MutualFundDetails { MutualFundId = 1007, MutualFundName = "LIC", MutualFundValue = 700.94},
            new MutualFundDetails { MutualFundId = 1008, MutualFundName = "TATACAPITALS", MutualFundValue = 900.10},
            new MutualFundDetails { MutualFundId = 1009, MutualFundName = "NIPPON", MutualFundValue = 245.75},
            new MutualFundDetails { MutualFundId = 1010, MutualFundName = "KOTAK", MutualFundValue = 354.82}
        };
          public MutualFundDetails GetMutualFundByNameRepository(string mutualFundName)
          {
            MutualFundDetails mutualFundData = null;
            try
            {
                string mutualfundName = mutualFundName.ToUpper();
                _log4net.Info("In MutualFundRepository, MutualFundProvider has Called GetMutualFundByNameRepository and " + mutualFundName + " is searched");
                 mutualFundData = listOfFunds.Where(e => e.MutualFundName == mutualfundName).FirstOrDefault();    
                if(mutualFundData!=null)
                {
                    var jsonFund = JsonConvert.SerializeObject(mutualFundData);
                    _log4net.Info("Mutual Fund Found "+jsonFund);
                }
                else
                {
                    _log4net.Info("In MutualFundRepository, MutualFund "+mutualFundName+" is not found.");
                }
            }
            catch(Exception exception)
            {
                _log4net.Error("Exception occurred while finding the mutual fund details "+exception.Message);
            }
            return mutualFundData;
          }
    }
}