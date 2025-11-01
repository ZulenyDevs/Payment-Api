using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Payments
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string DocumentId { get; private set; }
        public string ExternalId { get; private set; }
        public string Channel { get; private set; }

        public Customer(string name, string documentId, string externalId, string channel) : base(Guid.NewGuid())
        {
            Name = name;
            DocumentId = documentId;
            ExternalId = externalId;
            Channel = channel;
        }

        public void Update(string name, string documentId, string externalId, string channel)
        {
            Name = name;
            DocumentId = documentId;
            ExternalId = externalId;
            Channel = channel;
        }
    }
}
