using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("payment")]
    public class PaymentStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("code")]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [Column("total_amount", TypeName = "numeric(15,2)")]
        public double TotalAmount { get; set; }

        [Required]
        [Column("currency")]
        [StringLength(10)]
        public string Currency { get; set; }

        [Required]
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }

        [Column("method")]
        [StringLength(100)]
        public string Method { get; set; }

        [Column("channel")]
        [StringLength(100)]
        public string Channel { get; set; }

        [Required]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        public CustomerStoredModel Customer { get; set; }
        public List<PaymentServiceStoredModel> PaymentServices { get; set; }

    }
}
