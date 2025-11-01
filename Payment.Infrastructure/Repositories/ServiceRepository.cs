using Microsoft.EntityFrameworkCore;
using Payment.Domain.Services;
using Payment.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    internal class ServiceRepository : IServiceRepository
    {
        private readonly DomainDbContext _dbContext;

        public ServiceRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Service entity)
        {
            await _dbContext.Service.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Service.Remove(obj);
        }
        public async Task<Service> GetByIdAsync(Guid id)
        {
            return await _dbContext.Service.FindAsync(id);
        }
        public Task<Service?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }
        public async Task<Guid> GetIdByNameAsync(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Guid.Empty;
            }

            var id = await _dbContext.Service
                .AsNoTracking()
                .Where(p => p.Name == name)
                .Select(p => p.Id)
                .FirstOrDefaultAsync(cancellationToken);

            return id;
        }
        public Task UpdateAsync(Service Service)
        {
            _dbContext.Service.Update(Service);

            return Task.CompletedTask;
        }
    }
}
