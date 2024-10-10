using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class WhitelistDomain
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String WhitelistedDomain { get; set; }

        public WhitelistDomain(String WhitelistedDomain, int EntityId)
        {
            this.WhitelistedDomain = WhitelistedDomain;
            this.EntityId = EntityId;
            this.Entity = null!;
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
