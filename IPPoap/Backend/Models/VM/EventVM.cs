using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class EventVM
    {
        public Boolean PoapManager { get; set; }

        public String Name { get; set; }

        public String Lat { get; set; }

        public String Long { get; set; }

        public DateTime Time { get; set; }

        public String Description { get; set; }

        public int Registed { get; set; }

        public int Max { get; set; }

        public Boolean Display { get; set; }

        public EventVM(Boolean PoapManager, String Name, String Lat, String Long, DateTime Time,
            String Description, int Registed, int Max, Boolean Display)
        {
            this.PoapManager = PoapManager;
            this.Name = Name;
            this.Lat = Lat;
            this.Long = Long;
            this.Time = Time;
            this.Description = Description;
            this.Registed = Registed;
            this.Max = Max;
            this.Display = Display;
        }
    }
}
