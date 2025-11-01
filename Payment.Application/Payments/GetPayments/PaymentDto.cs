using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Payments.GetPayments
{
	public class PaymentDto
	{
		public Guid paymentId { get; set; }
        public string serviceProvider { get; set; }
        public double amount { get; set; }
        public string status { get; set; }
        public DateTimeOffset createdAt { get; set; }

	}
}
