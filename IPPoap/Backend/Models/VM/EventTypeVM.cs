using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class EventTypeVM
    {
        public int Id { get; set; }

        public String Type { get; set; }

        public EventTypeVM(int Id, String Type)
        {
            this.Id = Id;
            this.Type = Type;
        }
    }
}
