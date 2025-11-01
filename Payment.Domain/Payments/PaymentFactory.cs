using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
	public class PaymentFactory : IPaymentFactory
	{

        public Payment Create(string code, double totalAmount, string currency, string status, string method, string channel, Guid customerId, List<(string billingPeriod, double amount, Guid serviceId)> paymentServices)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("customerId is required");
            }

            Payment payment = new Payment(code, totalAmount, currency, status, method, channel, customerId);

            foreach (var paymentService in paymentServices)
            {
                payment.AddPaymentService(paymentService.billingPeriod, paymentService.amount, paymentService.serviceId);
            }

            return payment;
        }
    }
}
