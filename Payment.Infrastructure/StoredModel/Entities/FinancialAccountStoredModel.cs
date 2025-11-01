using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("financial_account")]
    public class FinancialAccountStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("number")]
        [StringLength(100)]
        public string Number { get; set; }

        [Required]
        [Column("currency")]
        [StringLength(10)]
        public string Currency { get; set; }

        [Required]
        [Column("provider_id")]
        public Guid ProviderId { get; set; }

        [Required]
        [Column("financial_institution_id")]
        public Guid FinancialInstitutionId { get; set; }

        // Navigation properties
        public ProviderStoredModel Provider { get; set; }
        public FinancialInstitutionStoredModel FinancialInstitution { get; set; }
    }
}
