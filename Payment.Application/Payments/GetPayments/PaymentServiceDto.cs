using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Payments.GetPayments
{
	public class PaymentServiceDto
	{
		public Guid Id { get; set; }
        public string BillingPeriod { get; set; }
        public double Amount { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
