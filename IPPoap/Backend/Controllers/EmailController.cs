using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Controllers.Services;

namespace Backend.Controllers
{
    [Route("[controller]"), ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail(MailRequest mailRequest)
        {
            try
            {
                _emailService.SendEmail(mailRequest);
                return Ok();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
