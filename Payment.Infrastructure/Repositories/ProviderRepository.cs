
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Providers;
using Payment.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    internal class ProviderRepository : IProviderRepository
    {
        private readonly DomainDbContext _dbContext;

        public ProviderRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Provider entity)
        {
            await _dbContext.Provider.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Provider.Remove(obj);
        }
        public async Task<Provider> GetByIdAsync(Guid id)
        {
            return await _dbContext.Provider.FindAsync(id);
        }
        public Task<Provider?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }
        public async Task<Guid> GetIdByNameAsync(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Guid.Empty;
            }

            var id = await _dbContext.Provider
                .AsNoTracking()
                .Where(p => p.Name == name)
                .Select(p => p.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return id;
        }
        public Task UpdateAsync(Provider Provider)
        {
            _dbContext.Provider.Update(Provider);

            return Task.CompletedTask;
        }
    }
}
