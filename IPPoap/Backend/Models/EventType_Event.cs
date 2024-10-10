using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class EventType_Event
    {
        public EventType_Event(int EventTypeId, int EventId)
        {
            this.EventTypeId = EventTypeId;
            this.EventType = null!;
            this.EventId = EventId;
            this.Event = null!;
        }

        // Foreign Keys
        [ForeignKey("EventTypeId")]
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        [ForeignKey("EventId")]
        public int EventId { get; set; }    
        public virtual Event Event { get; set; }
    }
}
