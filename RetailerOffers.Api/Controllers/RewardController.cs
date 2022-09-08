using RetailerOffers.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using NSwag.Annotations;
using RetailerOffers.Business.DomainModels;
using System.Collections.Generic;

namespace RetailerOffers.Controllers
{
    /// <summary>
    /// This is reward controller for calcaulting the rewards
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly ILogger<RewardController> _logger;
        private readonly ITransactionServices _transactionServices;

        public RewardController(ILogger<RewardController> logger, ITransactionServices transactionServices)
        {
            _logger = logger;
            _transactionServices = transactionServices;
        }

        /// <summary>
        /// Get Total User rewards user has till present day
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserRewards(int customer)
        {
            if (customer < 0) return BadRequest("Invalid Customer Id");
            var result = _transactionServices.GetTotaUserRewards(customer);
            return Ok($"Customer has Total {result} rewards points");
        }
        /// <summary>
        /// Get Total User rewards user.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, typeof(TransactionModel))]
        [SwaggerResponse(500, typeof(string))]
        [HttpGet("GetAllUserRewards")]
        public ActionResult<List<TransactionModel>> GetGetAllUserRewards()
        {
            var result = _transactionServices.GetGetAllUserRewards();

            return new ObjectResult(200) { StatusCode = 200, Value = result };
        }
        /// <summary>
        /// Get Total User rewards user.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, typeof(TransactionModel))]
        [SwaggerResponse(500, typeof(string))]
        [HttpGet("GetGetAllUserRewardsById")]
        public ActionResult<List<TransactionModel>> GetAllUserRewardsbyId(int customerId)
        {
            var result = _transactionServices.GetAllUserRewardsbyId(customerId);

            return Ok(result);
        }

        /// <summary>
        /// Get Rewards for the past 3 months of customer
        /// </summary>
        /// <returns></returns>
        [HttpGet("{months}")]
        public IActionResult GetThreeMonthsRewards(int customer,int months = 3)
        {
            var startDate = DateTime.Now.AddMonths(-3);

            if (customer < 0) return BadRequest("Invalid Customer Id");
            var result = _transactionServices.GetThreeMonthsRewards(customer, startDate);
            return Ok($"Customer has Total {result} rewards points for Past 3 months");
        }

        /// <summary>
        /// Calcualte the total reward point for the amount
        /// </summary>
        /// <returns></returns>
        [HttpGet("calculate")]
        public IActionResult CalculateRewards(int amount)
        {
            if (amount < 0) return BadRequest("Please Enter the valid Amount");
            var result = _transactionServices.CalculateRewardPoints(amount);
            return Ok(result);
        }

        /// <summary>
        /// Add the new reward based on the amount to the user
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost("transaction")]
        public IActionResult AddRewardTransaction(int customerId, int amount)
        {
            if (customerId < 0) return BadRequest("Please enter the valid customer id");
            _transactionServices.AddReward(customerId, amount);
            return Ok("Reward Successfully added");
        }
    }
}