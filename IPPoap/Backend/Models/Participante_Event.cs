using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Participante_Event
    {
        public Participante_Event(int ParticipanteId, int EventId)
        {
            this.Participante = null!;
            this.ParticipanteId = ParticipanteId;
            this.Event = null!;
            this.EventId = EventId;
        }

        // Foreign Keys
        [ForeignKey("ParticipanteId")]
        public int ParticipanteId { get; set; }
        public virtual Participante Participante { get; set; }
        
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
