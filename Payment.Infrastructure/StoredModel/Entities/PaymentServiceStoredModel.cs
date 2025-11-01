using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("payment_service")]
    public class PaymentServiceStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("billing_period")]
        [StringLength(50)]
        public string BillingPeriod { get; set; }

        [Required]
        [Column("amount", TypeName = "numeric(15,2)")]
        public double Amount { get; set; }

        [Required]
        [Column("payment_id")]
        public Guid PaymentId { get; set; }

        [Required]
        [Column("service_id")]
        public Guid ServiceId { get; set; }

        // Navigation properties
        public PaymentStoredModel Payment { get; set; }
        public ServiceStoredModel Service { get; set; }
    }
}
