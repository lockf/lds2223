using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class ImageVM
    {
        public String FileName { get; set; }

        public byte[] ImageData { get; set; }

        public ImageVM(String FileName, byte[] ImageData)
        {
            this.FileName = FileName;
            this.ImageData = ImageData;
        }
    }
}
