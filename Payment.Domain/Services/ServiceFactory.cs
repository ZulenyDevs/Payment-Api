using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Services
{
	public class ServiceFactory : IServiceFactory
	{
		public Service Create(string name, Guid categoryId, Guid providerId)
		{
			if (categoryId == Guid.Empty || providerId == Guid.Empty)
			{
				throw new ArgumentException("categoryId and providerId are required");
			}

			Service service = new Service(name, categoryId, providerId);
			
			return service;
		}
	}
}
