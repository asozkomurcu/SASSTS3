using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Services.Abstraction;

namespace SASSTS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> MailTest()
        {
           await  _mailService.SendMessageAsync("asozkmrc@gmail.com", "Örnek mail", "<strong>Bu bir örnek maildir.</strong>");
            return Ok();
        }
    }
}
