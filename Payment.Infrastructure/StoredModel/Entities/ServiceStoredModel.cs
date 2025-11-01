using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("service")]
    public class ServiceStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("category_id")]
        public Guid CategoryId { get; set; }

        [Required]
        [Column("provider_id")]
        public Guid ProviderId { get; set; }

        // Navigation properties
        public CategoryStoredModel Category { get; set; }
        public ProviderStoredModel Provider { get; set; }
        public List<PaymentServiceStoredModel> PaymentServices { get; set; }
    }
}
