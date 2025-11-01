using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("financial_institution")]
    public class FinancialInstitutionStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("type")]
        [StringLength(100)]
        public string Type { get; set; }

        [Required]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [Column("country")]
        [StringLength(100)]
        public string Country { get; set; }

        // Navigation properties
        public List<FinancialAccountStoredModel> FinancialAccounts { get; set; }
    }
}
