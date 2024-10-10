using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public Boolean Display { get; set; }

        public Manager(String Name, String Email, String Password, int GroupId)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Display = true;
            this.GroupId = GroupId;
            this.Group = null!;
            this.Events = new();
        }

        // Foreign Keys
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
