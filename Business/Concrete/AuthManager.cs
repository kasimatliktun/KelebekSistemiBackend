using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;// kullanıcı varmı yokmu kontrolü için
        private ITokenHelper _tokenHelper;// token vermeyi bununla yapıyoruz
        private IUserOperationClaimService _userOperationClaimService;
        private IOperationClaimService _operationClaimService;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;


        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Numara = userForRegisterDto.Numara,
                Sinif = userForRegisterDto.Sinif,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Password = password,                
                Status = true
            };
            _userService.Add(user);
            int roleId = _operationClaimService.GetAll().Data.FirstOrDefault(r => r.Name == "student").Id;

            var userOperationClaim = new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = roleId
            };

            _userOperationClaimService.Add(userOperationClaim);

            return  new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);// önce kullanıcı mailine göre getiriyoruz
            if (userToCheck==null)//kullanıcı var mı kontrolü
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            // şifreyi hashleyip kontrol ediyoruz
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck,Messages.SuccessfulLogin);
        }
        //Kullanıcı olup olmadığını kontrol ediyor. Öğrenci için bu kontrolü kullanabiliriz.
        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);//kullanıcının rollerini veriyor
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }
    }
}
