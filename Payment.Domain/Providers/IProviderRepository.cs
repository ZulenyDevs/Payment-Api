using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Providers
{
	public interface IProviderRepository : IRepository<Provider>
	{
        Task<Guid> GetIdByNameAsync(string name, CancellationToken cancellationToken);
        Task UpdateAsync(Provider provider);
		Task DeleteAsync(Guid id);
	}
}
