using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public Group(String Name, int EntityId)
        {
            this.Name = Name;
            this.EntityId = EntityId;
            this.Entity = null!;
            this.Managers = new();
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual List<Manager> Managers { get; set; }
    }
}
