using Microsoft.EntityFrameworkCore;
using Payment.Domain.Abstractions;
using Payment.Domain.Services;
using Payment.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Providers;

namespace Payment.Infrastructure.DomainModel
{
    public class DomainDbContext(DbContextOptions<DomainDbContext> options) : DbContext(options)
    {
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Payment.Domain.Payments.Payment> Payment { get; set; } // Fully qualify 'Payment' to avoid ambiguity
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PaymentService> PaymentService { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
