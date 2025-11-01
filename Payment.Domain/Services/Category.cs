using Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Services
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(string name, string description) : base(Guid.NewGuid())
        {
            Name = name;
            Description = description;
        }

        internal void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
