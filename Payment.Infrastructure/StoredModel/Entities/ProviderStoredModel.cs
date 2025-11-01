using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.StoredModel.Entities
{
    [Table("provider")]
    public class ProviderStoredModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Column("nit")]
        [StringLength(50)]
        public string Nit { get; set; }

        [Column("address")]
        [StringLength(500)]
        public string Address { get; set; }

        [Column("phone_number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        // Navigation properties
        public List<ServiceStoredModel> Services { get; set; }
        public List<FinancialAccountStoredModel> FinancialAccounts { get; set; }
    }
}
