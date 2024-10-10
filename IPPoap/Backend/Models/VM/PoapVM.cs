using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class PoapVM
    {
        public String Name { get; set; }

        public String PoapFancyId { get; set; }

        public ImageVM ImageVM { get; set; }

        public PoapVM(String Name, String PoapFancyId, ImageVM imageVM)
        {
            this.Name = Name;
            this.PoapFancyId = PoapFancyId;
            this.ImageVM = imageVM;
        }
    }
}
