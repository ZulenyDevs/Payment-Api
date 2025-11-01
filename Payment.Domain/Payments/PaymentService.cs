using Payment.Domain.Abstractions;
using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
    public class PaymentService : Entity
    {
        public string BillingPeriod { get; private set; }
        public AmountValue Amount { get; private set; }
        public Guid PaymentId { get; private set; }
        public Guid ServiceId { get; private set; }

        private PaymentService() : base(Guid.Empty)
        {
        }

        public PaymentService(string billingPeriod, double amount, Guid paymentId, Guid serviceId) : base(Guid.NewGuid())
        {
            BillingPeriod = billingPeriod;
            Amount = amount;
            PaymentId = paymentId;
            ServiceId = serviceId;
        }


        public void Update(string billingPeriod, double amount, Guid paymentId, Guid serviceId)
        {
            BillingPeriod = billingPeriod;
            Amount = amount;
            PaymentId = paymentId;
            ServiceId = serviceId;
        }
    }
}
