using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        public Admin(String Name, String Email, String Password, int EntityId)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.EntityId = EntityId;
            this.Events = new();
            this.Entity = null!;
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
