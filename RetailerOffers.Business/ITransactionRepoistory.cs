using RetailerOffers.Business.DomainModels;
using System;
using System.Collections.Generic;

namespace RetailerOffers.Business
{
    public interface ITransactionRepoistory
    {
       // List<TransactionModel> GetAllUserRewards(int customerId);
        void AddReward(TransactionModel transaction);
        List<TransactionModel> GetUserRewards(int customerId, DateTime startDate);
        List<TransactionModel> GetAllUserRewards();
        List<TransactionModel> GetAllUserRewardsbyId(int customerId);
    }
}