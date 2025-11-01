using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Application.Payments.GetPayments;
using Payment.Infrastructure.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Handlers.Payment
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<PaymentDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetPaymentsHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<PaymentDto>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Payment
                .AsNoTracking()
                .Include(p => p.Customer)
                .Include(p => p.PaymentServices)
                    .ThenInclude(ps => ps.Service)
                        .ThenInclude(s => s.Category)
                .Include(p => p.PaymentServices)
                    .ThenInclude(ps => ps.Service)
                        .ThenInclude(s => s.Provider)
                .AsQueryable();

            // Filtrar por CustomerId si se proporciona
            if (request.CustomerId != Guid.Empty)
            {
                query = query.Where(p => p.CustomerId == request.CustomerId);
            }

            return await query
                .Select(i => new PaymentDto()
                {
                    paymentId = i.Id,
                    serviceProvider = i.PaymentServices.FirstOrDefault().Service.Name,
                    amount = i.TotalAmount,
                    status = i.Status,
                    createdAt = i.CreatedAt,
                })
                .ToListAsync(cancellationToken);
        }

    }
}
