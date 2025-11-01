using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
	public interface IPaymentFactory
	{
        Payment Create(string code, double totalAmount, string currency, string status, string method, string channel, Guid customerId, List<(string billingPeriod, double amount, Guid serviceId)> paymentServices);
	}
}
