namespace Backend.Models.VM
{
    public class EventVMv2
    {
        public String Name { get; set; }

        public String Lat { get; set; }

        public String Long { get; set; }

        public DateTime Time { get; set; }

        public String Description { get; set; }

        public int Registed { get; set; }

        public int Max { get; set; }

        public EventVMv2(string name, string lat, string lng, DateTime time, string description, int registed, int max)
        {
            this.Name = name;
            this.Lat = lat;
            this.Long = lng;
            this.Time = time;
            this.Description = description;
            this.Registed = registed;
            this.Max = max;
        }
    }
}
