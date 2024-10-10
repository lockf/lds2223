using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class EventCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean PoapManager { get; set; }

        [Required]
        public String Name { get; set; }


        [Required]
        public String Lat { get; set; }

        [Required]
        public String Long { get; set; }

        [Required]
        public DateTime Time { get; set; }
        
        [Required]
        public String Organizer { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public int Registed { get; set; }

        [Required]
        public int Max { get; set; }
        
        [Required]
        public Boolean Display { get; set; }
    }
}
