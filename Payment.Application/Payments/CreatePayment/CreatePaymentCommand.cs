using MediatR;
using System;
using System.Collections.Generic;

namespace Payment.Application.Payments.CreatePayment
{
	public record CreatePaymentServiceCommand(string billingPeriod, double amount, Guid serviceId) : IRequest<Guid>;

	public record CreateCustomerCommand(string name, string documentId, string externalId, string channel) : IRequest<Guid>;

    public record CreatePaymentCommand(Guid customerId, string serviceProvider, double amount) : IRequest<Guid>;
}
