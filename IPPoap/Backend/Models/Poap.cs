using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Poap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String PoapFancyId { get; set; }

        public Poap(String Name, String PoapFancyId, int EventId, int ImageId)
        {
            this.Name = Name;
            this.PoapFancyId= PoapFancyId;
            this.EventId = EventId;
            this.Event = null!;
            this.ImageId= ImageId;
            this.Image= null!;
        }

        // Foreign Keys
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
