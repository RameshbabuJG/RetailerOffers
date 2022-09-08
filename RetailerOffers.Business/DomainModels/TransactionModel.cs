using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailerOffers.Business.DomainModels
{
    public class TransactionModel
    {
        public int CustomerId { get; set; }

        public int TransactionId { get; set; }

        public int TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        public int RewardPoints { get; set; }
    }
}
