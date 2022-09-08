using RetailerOffers.Business.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailerOffers.Business
{
    public class TransactionServices : ITransactionServices
    {
        private ITransactionRepoistory _transactionRepoistory;

        public TransactionServices(ITransactionRepoistory transactionRepoistory)
        {
            _transactionRepoistory = transactionRepoistory;
        }

        public void AddReward(int customerId, int amount)
        {
            var reward = CalculateRewardPoints(amount);
            var transaction = new TransactionModel()
            {
                CustomerId = customerId,
                TransactionAmount = amount,
                RewardPoints = reward,
                TransactionDate = DateTime.Now
            };
            _transactionRepoistory.AddReward(transaction);
        }

        public int GetTotaUserRewards(int customerId)
        {
            var userRewards = _transactionRepoistory.GetUserRewards(customerId, DateTime.MinValue);
            return userRewards == null? 0 : userRewards.Select(x => x.RewardPoints).Sum();
        }

        public int GetThreeMonthsRewards(int customerId, DateTime startDate)
        {
            var userRewards = _transactionRepoistory.GetUserRewards(customerId, startDate);
            return userRewards == null ? 0 : userRewards.Select(x => x.RewardPoints).Sum();
        }

        public int CalculateRewardPoints(int amount)
        {
            if (amount >= 50 && amount < 100)
                return amount - 50;
            else if (amount > 100)
                return (2 * (amount - 100) + 50);
            return 0;
        }

        public List<TransactionModel> GetGetAllUserRewards()
        {
            return _transactionRepoistory.GetAllUserRewards();
        }

        public List<TransactionModel> GetAllUserRewardsbyId(int customerId)
        {
            return _transactionRepoistory.GetAllUserRewardsbyId(customerId);
        }
        
    }
}