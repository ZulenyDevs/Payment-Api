using Payment.Domain.Payments;
using Payment.Infrastructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly DomainDbContext _dbContext;

        public PaymentRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Domain.Payments.Payment entity)
        {
            await _dbContext.Payment.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Payment.Remove(obj);
        }
        public async Task<Domain.Payments.Payment> GetByIdAsync(Guid id)
        {
            return await _dbContext.Payment.FindAsync(id);
        }
        public Task<Domain.Payments.Payment?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Payments.Payment payment)
        {
            _dbContext.Payment.Update(payment);

            return Task.CompletedTask;
        }
    }
}
