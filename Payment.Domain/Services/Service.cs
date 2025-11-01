using Payment.Domain.Abstractions;
using Payment.Domain.Services.Events;
using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Payment.Domain.Services
{
    public class Service : AggregateRoot
    {
        public string Name { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid ProviderId { get; private set; }

        public Service(string name, Guid categoryId, Guid providerId) : base(Guid.NewGuid())
        {
            Name = name;
            CategoryId = categoryId;
            ProviderId = providerId;
        }

        public void Complete()
        {
            // AddDomainEvent(new ServiceCreated(Id, Name, CategoryId, ProviderId));
        }
    }
}
