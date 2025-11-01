using Payment.Domain.Abstractions;
using Payment.Domain.Services.Events;
using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Payment.Domain.FinancialAccounts
{
    public class FinancialAccount : AggregateRoot
    {
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Currency { get; private set; }
        public Guid ProviderId { get; private set; }
        public Guid FinancialInstitutionId { get; private set; }

        protected FinancialAccount() { }

        public FinancialAccount(string name, string number, string currency, Guid providerId, Guid financialInstitutionId) : base(Guid.NewGuid())
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name no puede ser nulo o vacío.", nameof(name));

            Name = name;
            Number = number;
            Currency = currency;
            ProviderId = providerId;
            FinancialInstitutionId = financialInstitutionId;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nuevo nombre no puede ser nulo o vacío.", nameof(newName));

            this.Name = newName;
        }

        public void Complete()
        {
            // AddDomainEvent(new FinancialAccountCompleted(Id));
        }
    }
}
