
using RetailerOffers.Business.DomainModels;
using System;
using System.Collections.Generic;

namespace RetailerOffers.Business
{
    public interface ITransactionServices
    {
        int CalculateRewardPoints(int amount);
        int GetTotaUserRewards(int customer);
        int GetThreeMonthsRewards(int customer, DateTime startDate);
        void AddReward(int customerId, int amount);

        List<TransactionModel> GetGetAllUserRewards();
        List<TransactionModel> GetAllUserRewardsbyId(int customerId);
        
    }
}