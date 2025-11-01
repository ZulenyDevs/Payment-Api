using Microsoft.EntityFrameworkCore;
using Payment.Domain.Abstractions;
using Payment.Infrastructure.Repositories;
using Payment.Infrastructure.StoredModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext, IDatabase
    {
        public virtual DbSet<PaymentStoredModel> Payment { get; set; }
        public DbSet<PaymentServiceStoredModel> PaymentService { get; set; }

        public DbSet<CustomerStoredModel> Customer { get; set; }
        public virtual DbSet<ServiceStoredModel> Service { get; set; }
        public DbSet<CategoryStoredModel> Category { get; set; }
        public  DbSet<ProviderStoredModel> Provider { get; set; }
        public virtual DbSet<FinancialAccountStoredModel> FinancialAccount { get; set; }
        public DbSet<FinancialInstitutionStoredModel> FinancialInstitution { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Migrate()
        {
            Database.Migrate();
        }
    }
}
