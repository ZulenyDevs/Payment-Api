using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.FinancialAccounts
{
	public class FinancialAccountFactory : IFinancialAccountFactory
	{
		public FinancialAccount Create(string name, Guid categoryId, Guid providerId)
		{
			if (categoryId == Guid.Empty || providerId == Guid.Empty)
			{
				throw new ArgumentException("categoryId and providerId are required");
			}

			//FinancialAccount service = new FinancialAccount(name, categoryId, providerId);
			
			return null;
		}
	}
}
