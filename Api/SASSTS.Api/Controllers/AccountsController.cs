using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SASSTS.Application.Models.Dtos.TokenDtos;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Wrapper;

namespace SASSTS.Api.Controllers
{
    [Route("account")]
    [ApiController]
    //[Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMailService _mailService;
        private readonly IMessageService _messageService;

        public AccountsController(IAccountService accountService, IMailService mailService, IMessageService messageService)
        {
            _accountService = accountService;
            _mailService = mailService;
            _messageService = messageService;
        }

        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        
        public async Task<ActionResult<Result<int>>> Register(RegisterVM createUserVM)
        {
            var result = await _accountService.Register(createUserVM);
            await _mailService.SendMessageAsync($"{createUserVM.Email}", _messageService.SubjectMessage(), _messageService.RegisterMessage(createUserVM));
            return Ok(result);
        }


        [HttpPost("login")]
        //[AllowAnonymous]
        public async Task<ActionResult<Result<TokenDto>>> Login(LoginVM loginVM)
        {
            var result = await _accountService.Login(loginVM);
            return Ok(result);
        }

        [HttpPut("update/{id:int?}")]
        public async Task<ActionResult<Result<int>>> UpdateUser(int? id, UpdateUserVM updateUserVM)
        {
            if (id != updateUserVM.Id)
            {
                return BadRequest();
            }
            var result = await _accountService.UpdateUser(updateUserVM);
            return Ok(result);
        }
    }
}
