using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SASSTS.Application.Behaviors;
using SASSTS.Application.Exceptions;
using SASSTS.Application.Models.Dtos.TokenDtos;
using SASSTS.Application.Models.RequestModels.AccountsRM;
using SASSTS.Application.Services.Abstraction;
using SASSTS.Application.Validators.AccountsValidators;
using SASSTS.Application.Wrapper;
using SASSTS.Domain.Entities;
using SASSTS.Domain.UWork;
using SASSTS.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SASSTS.Application.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailSrvice;
        private readonly Customer customer;

        public AccountService(IMapper mapper, IUnitWork unitWork, IConfiguration configuration, IMailService mailSrvice)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _configuration = configuration;
            _mailSrvice = mailSrvice;
        }

        [ValidationBehavior(typeof(RegisterValidator))]
        public async Task<Result<bool>> Register(RegisterVM createUserVM)
        {
            var result = new Result<bool>();

            var identityNumberExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.IdentityNumber.Trim().ToUpper() == createUserVM.IdentityNumber.Trim().ToUpper());
            if (identityNumberExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz TC kimlik numarası kayıtlı.");
            }

            var phoneExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Phone.Trim().ToUpper() == createUserVM.Phone.Trim().ToUpper());
            if (phoneExists)
            {
                throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı.");
            }

            var emailExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Email.Trim().ToUpper() == createUserVM.Email.Trim().ToUpper());
            if (emailExists)
            {
                throw new AlreadyExistsException($"{createUserVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            }

            var departmentExistsSame = await _unitWork.GetRepository<Department>().AnyAsync(x => x.DepartmentName == createUserVM.DepartmentName && x.Id == createUserVM.DepartmentId);
            if (!departmentExistsSame)
            {
                throw new NotFoundException($"Girilen departman bilgileri eşleşmiyor veya kayıtlı değil.");
            }





            var customerEntity = _mapper.Map<Customer>(createUserVM);
            var accountEntity = _mapper.Map<Account>(createUserVM);
            accountEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], accountEntity.Password);
            customerEntity.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], customerEntity.Password);
            accountEntity.Customer = customerEntity;

            _unitWork.GetRepository<Customer>().Add(customerEntity);
            _unitWork.GetRepository<Account>().Add(accountEntity);
            result.Data = await _unitWork.CommitAsync();



            return result;
        }

        [ValidationBehavior(typeof(LoginValidator))]
        public async Task<Result<TokenDto>> Login(LoginVM loginVM)
        {
            var result = new Result<TokenDto>();

            var hashedPassword = CipherUtil.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);

            var existsAccount = await _unitWork.GetRepository<Account>().GetSingleByFilterAsync(x => x.Email == loginVM.Email && x.Password == hashedPassword, "Customer");

            if (existsAccount is null)
            {
                throw new NotFoundException($"{loginVM.Email} Email adresine sahip personel bulunamadı ya da parola hatalıdır.");
            }


            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var expireDate = DateTime.Now.AddMinutes(expireMinute);


            var tokenString = GenerateJwtToken(existsAccount, expireDate);

            result.Data = new TokenDto
            {
                Token = tokenString,
                ExpireDate = expireDate,
                Role = existsAccount.Customer.Role
            };

            return result;
        }


        [ValidationBehavior(typeof(UpdateUserValidator))]
        public async Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM)
        {
            var result = new Result<bool>();

            //var phoneExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Phone.Trim().ToUpper() == updateUserVM.Phone.Trim().ToUpper());
            //if (phoneExists)
            //{
            //    throw new AlreadyExistsException($"Girmiş olduğunuz telefon numarası kayıtlı.");
            //}

            //var emailExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Email.Trim().ToUpper() == updateUserVM.Email.Trim().ToUpper());
            //if (emailExists)
            //{
            //    throw new AlreadyExistsException($"{updateUserVM.Email} eposta adresi kullanılmaktadır. Lütfen farklı bir kullanıcı adı belirleyiniz.");
            //}

            //var existsCustomer = await _unitWork.GetRepository<Customer>().GetById(updateUserVM.Id.Value);

            //existsCustomer.Password = CipherUtil
            //    .EncryptString(_configuration["AppSettings:SecretKey"], existsCustomer.Password);

            //_mapper.Map(updateUserVM, existsCustomer);

            //_unitWork.GetRepository<Customer>().Update(existsCustomer);
            //result.Data = await _unitWork.CommitAsync();

            //return result;



            var customerExists = await _unitWork.GetRepository<Customer>().GetById(updateUserVM.Id);
            if (customerExists is null)
            {
                throw new NotFoundException($"{updateUserVM.Id} numaralı tedarikçi bulunamadı.");
            }

            var newPassword = updateUserVM.Password;
            newPassword = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], newPassword);

            var customerPasswordExists = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Password == newPassword);
            if (customerPasswordExists)
            {
                throw new AlreadyExistsException($"Eski parola ve yeni parola bilgisi aynı olamaz.");
            }
            //var customer2Entity = _mapper.Map<Customer2>(UpdateCustomer2User);
            var customerUpdate = _mapper.Map(updateUserVM, customerExists);

            customerUpdate.Password = CipherUtil
                .EncryptString(_configuration["AppSettings:SecretKey"], customerUpdate.Password);

            _unitWork.GetRepository<Customer>().Update(customerUpdate);
            await _unitWork.CommitAsync();

            //result.Data = customerUpdate;
            _unitWork.Dispose();
            return result;
        }
        //public async Task<Result<int>> UpdateCustomer2User(UpdateCustomer2User updateCustomer2User)
        //{
        //    var result = new Result<int>();

        //    var customer2Exists = await _unitWork.GetRepository<Customer2>().GetById(updateCustomer2User.Id);
        //    if (customer2Exists is null)
        //    {
        //        throw new NotFoundException($"{updateCustomer2User.Id} numaralı tedarikçi bulunamadı.");
        //    }

        //    var newPassword = updateCustomer2User.Password;
        //    newPassword = CipherUtil
        //        .EncryptString(_configuration["AppSettings:SecretKey"], newPassword);

        //    var customer2PasswordExists = await _unitWork.GetRepository<Customer2>().AnyAsync(x => x.Password == newPassword);
        //    if (customer2PasswordExists)
        //    {
        //        throw new AlreadyExistsException($"Eski parola ve yeni parola bilgisi aynı olamaz.");
        //    }
        //    //var customer2Entity = _mapper.Map<Customer2>(UpdateCustomer2User);
        //    var customer2Update = _mapper.Map(updateCustomer2User, customer2Exists);

        //    customer2Update.Password = CipherUtil
        //        .EncryptString(_configuration["AppSettings:SecretKey"], customer2Update.Password);

        //    _unitWork.GetRepository<Customer2>().Update(customer2Update);
        //    await _unitWork.CommitAsync();

        //    result.Data = customer2Update.Id;
        //    _unitWork.Dispose();
        //    return result;
        //}

        private string GenerateJwtToken(Account account, DateTime expireDate)
        {
            var secretKey = _configuration["Jwt:SigningKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audiance = _configuration["Jwt:Audiance"];

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid,account.CustomerId.ToString()),
                new Claim(ClaimTypes.Name,account.Customer.Name),
                new Claim(ClaimTypes.Surname,account.Customer.Surname),
                new Claim(ClaimTypes.Email,account.Customer.Email),
                new Claim(ClaimTypes.Role,account.Customer.Role.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
