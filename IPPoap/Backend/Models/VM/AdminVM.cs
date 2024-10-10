using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class AdminVM
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public int EventsCreated { get; set; }

        public AdminVM(int id, string name, string email, int eventsCreated)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.EventsCreated = eventsCreated;
        }
    }
}
