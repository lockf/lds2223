using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public String Type { get; set; }

        public EventType(String Type)
        {
            this.Type = Type;
            this.EventType_Events = new();
        }

        public virtual List<EventType_Event> EventType_Events { get; set; }
    }
}
