using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String FileName { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

         public Image(String FileName, byte[] ImageData, int EventId)
        {
            this.FileName = FileName;
            this.ImageData = ImageData;
            this.EventId = EventId;
            this.Event = null!;
        }

        // Foreign Keys
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        
    }
}
