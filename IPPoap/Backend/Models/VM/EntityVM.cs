using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class EntityVM
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public EntityVM(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
