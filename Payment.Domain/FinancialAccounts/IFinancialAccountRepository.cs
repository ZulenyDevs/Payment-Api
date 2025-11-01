using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.FinancialAccounts
{
	public interface IFinancialAccountRepository : IRepository<FinancialAccount>
	{
		Task UpdateAsync(FinancialAccount service);
		Task DeleteAsync(Guid id);
	}
}
