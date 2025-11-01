using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.FinancialAccounts
{
    public class Provider : Entity
    {
        public string Name { get; private set; }
        public string Nit { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }

        protected Provider() { }

        public Provider(string name, string nit, string address, string phoneNumber) : base(Guid.NewGuid())
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre del proveedor no puede ser nulo o vacío.", nameof(name));

            Name = name;
            Nit = nit;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        internal void Update( string name, string nit, string address,string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.", nameof(name));

            Name = name;
            Nit = nit;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
