using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        IOperationClaimService _operationClaimService;

        public UserManager(IUserDal userDal, IOperationClaimService operationClaimService)
        {
            _userDal = userDal;
            _operationClaimService = operationClaimService;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
            var roleId = _operationClaimService.GetAll().Data.FirstOrDefault(r => r.Name == "user")?.Id;
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
