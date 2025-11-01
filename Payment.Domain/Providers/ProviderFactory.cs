using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Providers
{
	public class ProviderFactory : IProviderFactory
	{
		public Provider Create(string name, string nit, string address, string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(nit))
			{
				throw new ArgumentException("El NIT no puede ser nulo o vacío.", nameof(nit));
			}
			
			Provider provider = new Provider(name, nit, address, phoneNumber);
			
			return provider;
		}
	}
}
