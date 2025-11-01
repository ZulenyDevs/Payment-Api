using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Providers
{
	public interface IProviderFactory
	{
		Provider Create(string name, string nit, string address, string phoneNumber);
	}
}
