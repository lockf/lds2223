using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class GroupVM
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public GroupVM(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
