using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public Entity(String Name)
        {
            this.Name = Name;
            this.WhitelistDomains = new();
            this.WhitelistEmails = new();
            this.Events = new();
            this.Admins = new();
            this.Groups = new();
            this.Participantes = new();
        }

        // Foreign Keys
        public virtual List<WhitelistDomain> WhitelistDomains { get; set; }
        public virtual List<WhitelistEmail> WhitelistEmails { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual List<Admin> Admins { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<Participante> Participantes { get; set; }
    }
}
