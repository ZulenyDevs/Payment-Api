using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("customer")]
    public class CustomerStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("document_id")]
        [StringLength(50)]
        public string DocumentId { get; set; }

        [Column("external_id")]
        [StringLength(100)]
        public string ExternalId { get; set; }

        [Column("channel")]
        [StringLength(100)]
        public string Channel { get; set; }

        // Navigation properties
        public List<PaymentStoredModel> Payments { get; set; }
    }
}
