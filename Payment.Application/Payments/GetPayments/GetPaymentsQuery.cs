using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Payments.GetPayments
{
	public record GetPaymentsQuery(Guid CustomerId) : IRequest<IEnumerable<PaymentDto>>;
}
