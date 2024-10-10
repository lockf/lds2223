using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class MailRequest
    {
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Link { get; set; }

        public MailRequest(string ToEmail, string Subject, string Link)
        {
            this.ToEmail = ToEmail;
            this.Subject = Subject;
            this.Link = Link;
        }

        public MailRequest(string ToEmail, string Subject)
        {
            this.ToEmail = ToEmail;
            this.Subject = Subject;
        }
    }
}
