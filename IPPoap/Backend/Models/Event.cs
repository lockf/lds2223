using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean PoapManager { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Organizer { get; set; }

        [Required]
        public String Lat { get; set; }

        [Required]
        public String Long { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public int Registed { get; set; }

        [Required]
        public int Max { get; set; }

        [Required]
        public Boolean Display { get; set; }

        public Event(Boolean PoapManager, String Name, String Organizer, String Lat, String Long, DateTime Time, 
            String Description, int Registed, int Max, Boolean Display, int EntityId, int? AdminId, int? ManagerId)
        {
            this.PoapManager = PoapManager;
            this.Name = Name;
            this.Organizer = Organizer;
            this.Lat = Lat;
            this.Long = Long;
            this.Time = Time;
            this.Description = Description;
            this.Registed = Registed;
            this.Max = Max;
            this.Display = Display;
            this.EntityId = EntityId;
            this.AdminId= AdminId;
            this.ManagerId= ManagerId;
            this.Entity = null!;
            this.Admin = null!;
            this.Manager = null!;
            this.Images = new();
            this.Participante_Events = new();
            this.EventType_Events = new();
            this.Poaps= new();
        }

        // Foreign Keys
        [ForeignKey("EntityId")]
        public int EntityId { get; set; }
        public virtual Entity Entity { get; set; }

        [ForeignKey("AdminId")]
        public int? AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        [ForeignKey("ManagerId")]
        public int? ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        public virtual List<Image> Images { get; set; }
        public virtual List<Participante_Event> Participante_Events { get; set; }
        public virtual List<EventType_Event> EventType_Events { get; set; }
        public virtual List<Poap> Poaps { get; set; }
    }
}
