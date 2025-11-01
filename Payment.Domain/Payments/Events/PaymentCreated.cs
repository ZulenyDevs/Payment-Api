using Payment.Domain.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments.Events
{
	public record PaymentCreated(Guid Id, string Name, Guid categoryId, Guid providerId) : DomainEvent
	{
		public PaymentCreated() : this(Guid.Empty, string.Empty, Guid.Empty, Guid.Empty)
		{
		}

	}
}
