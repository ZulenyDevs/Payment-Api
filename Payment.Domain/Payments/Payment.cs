using Payment.Domain.Abstractions;
using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
    public class Payment : AggregateRoot
    {
        public string Code { get; private set; }
        public AmountValue TotalAmount { get; private set; }
        public string Currency { get; private set; }
        public string Status { get; private set; }
        public string Method { get; private set; }
        public string Channel { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public Guid CustomerId { get; private set; }

        private List<PaymentService> _paymentServices;
        public ICollection<PaymentService> PaymentService
        {
            get
            {
                return _paymentServices;
            }
        }
        private Payment() : base(Guid.Empty)
        {
            _paymentServices = new List<PaymentService>();
        }

        public Payment(string code, double totalAmount, string currency, string status, string method, string channel, Guid customerId) : base(Guid.NewGuid())
        {
            Code = code;
            TotalAmount = totalAmount;
            Currency = currency;
            Status = status;
            Method = method;
            Channel = channel;
            CreatedAt = DateTimeOffset.UtcNow;
            CustomerId = customerId;
            _paymentServices = new List<PaymentService>();
        }

        public void AddPaymentService(string billingPeriod, double amount, Guid serviceId)
        {
            var paymentService = new PaymentService(billingPeriod, amount, Id, serviceId);
            _paymentServices.Add(paymentService);
            RecalculateTotalAmount();
        }

        public void RemovePaymentService(Guid paymentServiceId)
        {
            var paymentService = _paymentServices.FirstOrDefault(ps => ps.Id == paymentServiceId);
            if (paymentService != null)
            {
                _paymentServices.Remove(paymentService);
                RecalculateTotalAmount();
            }
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public void UpdatePaymentMethod(string method, string channel)
        {
            Method = method;
            Channel = channel;
        }

        private void RecalculateTotalAmount()
        {
            TotalAmount = _paymentServices.Sum(ps => ps.Amount);
        }

        public void Complete()
        {
            // AddDomainEvent(new PaymentCreated(Id, Code, TotalAmount, Currency, Status, Method, Channel, CustomerId, _paymentServices));
        }
    }

}
