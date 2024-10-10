using System.ComponentModel.DataAnnotations;

namespace Backend.Services
{
    public class MailSettings
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Host { get; set; }

        [Required]
        public int Port { get; set; }
    }
}
