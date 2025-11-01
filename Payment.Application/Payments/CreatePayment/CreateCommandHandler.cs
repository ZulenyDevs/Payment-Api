using MediatR;
using Payment.Domain.Abstractions;
using Payment.Domain.Payments;
using Payment.Domain.Providers;
using Payment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Payment.Application.Payments.CreatePayment
{
	public class CreateCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
	{
		private readonly IPaymentFactory _paymentFactory;
		private readonly IPaymentRepository _paymentRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

		public CreateCommandHandler(IPaymentFactory paymentFactory,
			IPaymentRepository paymentRepository,
            IServiceRepository serviceRepository,
			IUnitOfWork unitOfWork)
		{
			_paymentFactory = paymentFactory;
			_paymentRepository = paymentRepository;
			_serviceRepository = serviceRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
		{

            string generatedCode = "PAY-" + Guid.NewGuid().ToString().Substring(0, 8);
            string generatedCurrency = "BOB";
            string generatedStatus = "Pending";
            string generatedMethod = "External";
            string generatedChannel = "WebHook";

            Guid serviceId = await _serviceRepository.GetIdByNameAsync(request.serviceProvider, cancellationToken);

            if (serviceId == Guid.Empty)
            {
                throw new InvalidOperationException($"No se puede crear el pago. El proveedor con nombre '{request.serviceProvider}' no fue encontrado o es inválido.");
            }

            var paymentServices = new List<(string billingPeriod, double amount, Guid serviceId)>
        {
            (
                billingPeriod: DateTime.Now.ToString("yyyyMM"),
                amount: request.amount,
                serviceId: serviceId
            )
        };

            var payment = _paymentFactory.Create(
                generatedCode,
                request.amount,
                generatedCurrency,
                generatedStatus,
                generatedMethod,
                generatedChannel,
                request.customerId,
                paymentServices
            );

            await _paymentRepository.AddAsync(payment);

            payment.Complete();

            await _unitOfWork.CommitAsync(cancellationToken);

            return payment.Id;

        }
	}
}
