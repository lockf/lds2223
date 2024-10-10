using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Participante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        public String Wallet { get; set; }

        public Participante(String Email, String Password, String Wallet, int EntityId)
        {
            this.Email = Email;
            this.Password = Password;
            this.Wallet = Wallet;
            this.EntityId = EntityId;
            this.Entity = null!;
            this.Participante_Events = new();
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }
        public virtual List<Participante_Event> Participante_Events { get; set; }
    }
}
