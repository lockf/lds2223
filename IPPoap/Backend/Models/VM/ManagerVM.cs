using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class ManagerVM
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public int EventsCreated { get; set; }

        public Boolean Display { get; set; }

        public int GroupId { get; set; }

        public ManagerVM(int Id, String Name, String Email, int EventsCreated, Boolean Display, int GroupId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.EventsCreated = EventsCreated;
            this.Display = Display;
            this.GroupId = GroupId;
        }
    }
}
