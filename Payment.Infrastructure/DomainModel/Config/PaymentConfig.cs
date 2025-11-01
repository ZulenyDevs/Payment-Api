using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment.Domain.Payments;
using Payment.Domain.Services;
using Payment.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.DomainModel.Config
{
    internal class PaymentConfig : IEntityTypeConfiguration<Payment.Domain.Payments.Payment>, IEntityTypeConfiguration<PaymentService>
    {
        public void Configure(EntityTypeBuilder<Payment.Domain.Payments.Payment> builder)
        {
            builder.ToTable("payment");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasMaxLength(100)
                .IsRequired();

            // Configurar AmountValue con ValueConverter
            var amountConverter = new ValueConverter<AmountValue, decimal>(
                amountValue => (decimal)amountValue.Value,
                amount => new AmountValue((double)amount)
            );

            builder.Property(x => x.TotalAmount)
                .HasConversion(amountConverter)
                .HasColumnName("total_amount")
                .HasColumnType("numeric(15,2)")
                .IsRequired();

            builder.Property(x => x.Currency)
                .HasColumnName("currency")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Method)
                .HasColumnName("method")
                .HasMaxLength(100);

            builder.Property(x => x.Channel)
                .HasColumnName("channel")
                .HasMaxLength(100);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            // Configurar relación con Customer
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relación con PaymentService (colección)
            builder.HasMany(x => x.PaymentService)
                .WithOne()
                .HasForeignKey(x => x.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<PaymentService> builder)
        {
            builder.ToTable("payment_service");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.BillingPeriod)
                .HasColumnName("billing_period")
                .HasMaxLength(50);

            // Configurar AmountValue con ValueConverter
            var amountConverter = new ValueConverter<AmountValue, decimal>(
                amountValue => (decimal)amountValue.Value,
                amount => new AmountValue((double)amount)
            );

            builder.Property(x => x.Amount)
                .HasConversion(amountConverter)
                .HasColumnName("amount")
                .HasColumnType("numeric(15,2)")
                .IsRequired();

            builder.Property(x => x.PaymentId)
                .HasColumnName("payment_id")
                .IsRequired();

            builder.Property(x => x.ServiceId)
                .HasColumnName("service_id")
                .IsRequired();

            // Configurar relación con Service
            builder.HasOne<Service>()
                .WithMany()
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
