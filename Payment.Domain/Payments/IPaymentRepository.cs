using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
	public interface IPaymentRepository : IRepository<Payment>
	{
		Task UpdateAsync(Payment service);
		Task DeleteAsync(Guid id);
	}
}
