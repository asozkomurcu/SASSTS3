using SASSTS.Application.Models.Dtos.TokenDtos;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);
        Task<Result<TokenDto>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);
    }
}
