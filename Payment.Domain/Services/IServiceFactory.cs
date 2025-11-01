using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Services
{
	public interface IServiceFactory
	{
		Service Create(string name, Guid categoryId, Guid providerId);
	}
}
