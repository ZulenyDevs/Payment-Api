using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Services
{
	public interface IServiceRepository : IRepository<Service>
	{
		Task UpdateAsync(Service service);
		Task DeleteAsync(Guid id);
        Task<Guid> GetIdByNameAsync(string name, CancellationToken cancellationToken);
    }
}
