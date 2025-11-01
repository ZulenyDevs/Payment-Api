using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.FinancialAccounts
{
	public interface IFinancialAccountFactory
	{
		FinancialAccount Create(string name, Guid categoryId, Guid providerId);
	}
}
