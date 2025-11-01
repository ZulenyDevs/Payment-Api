using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Domain.Abstractions
{
	public interface IUnitOfWork
	{
		Task CommitAsync(CancellationToken cancellationToken = default);
	}
}
