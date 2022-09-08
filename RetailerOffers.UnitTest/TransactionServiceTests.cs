using Moq;
using RetailerOffers.Business;
using RetailerOffers.Business.DomainModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace RetailerOffers.UnitTest
{
    public class TransactionServiceTests
    {
        private readonly List<TransactionModel> lstTransactions = new List<TransactionModel>();
        private readonly TransactionServices _transactionServices;
        private readonly Mock<TransactionRepoistory> _mockTransactionRepoistory;

        public TransactionServiceTests()
        {
            _mockTransactionRepoistory = new Mock<TransactionRepoistory>();
            _transactionServices = new TransactionServices(_mockTransactionRepoistory.Object);
        }

        [Theory]
        [InlineData(60)]
        [InlineData(120)]
        public void CalculateRewardsPoints_Should_Return_RewardPoints(int amount)
        {
            var reward = _transactionServices.CalculateRewardPoints(amount);
            Assert.True(reward > 0);

            if(amount == 60)
                Assert.Equal(10, reward);
            else
                Assert.Equal(90, reward);
        }

        [Fact]
        public void CalculateRewardsPoints_Should_Return_ZeroRewardPoints()
        {
            var reward = _transactionServices.CalculateRewardPoints(50);
            Assert.Equal(0, reward);
        }

        [Fact]
        public void GetTotaUserRewards_Should_Returns_All_Rewards_Total()
        {
            var rewards = _transactionServices.GetTotaUserRewards(100);
            Assert.Equal(44301, rewards);
        }

        [Fact]
        public void GetThreeMonthsRewards_Should_Returns_All_Rewards_Total()
        {
            var rewards = _transactionServices.GetThreeMonthsRewards(100, DateTime.Now.AddMonths(-3));
            Assert.Equal(29540, rewards);
        }
    }
}