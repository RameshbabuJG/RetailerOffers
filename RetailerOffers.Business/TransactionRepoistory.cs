using RetailerOffers.Business.DomainModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace RetailerOffers.Business
{
    public class TransactionRepoistory : ITransactionRepoistory
    {
        private static List<TransactionModel> userTransactions = new List<TransactionModel>();

        public TransactionRepoistory()
        {
            if(userTransactions.Count == 0)
                ReadDataSet();
        }

        public void AddReward(TransactionModel transaction) => userTransactions.Add(transaction);

        public List<TransactionModel> GetAllUserRewardsbyId(int customerId) => userTransactions.Where(_ => _.CustomerId.Equals(customerId)).ToList();

        public List<TransactionModel> GetAllUserRewards() => userTransactions.ToList();

        public List<TransactionModel> GetUserRewards(int customerId, DateTime startDate) => userTransactions.Where(_ => _.CustomerId.Equals(customerId) && _.TransactionDate > startDate).ToList();
    
        private void ReadDataSet()
        {
            using StreamReader reader = new StreamReader("Data.json");
            string dataJson = reader.ReadToEnd();
            userTransactions = JsonConvert.DeserializeObject<List<TransactionModel>>(dataJson);
        }
    }
}
