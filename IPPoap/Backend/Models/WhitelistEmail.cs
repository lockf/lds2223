using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class WhitelistEmail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String WhitelistedEmail { get; set; }

        public WhitelistEmail(String WhitelistedEmail, int EntityId)
        {
            this.WhitelistedEmail = WhitelistedEmail;
            this.EntityId = EntityId;
            this.Entity = null!;
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
    }
}
