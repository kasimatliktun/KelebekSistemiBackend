using Business.Constants;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
//using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    //buraya iş kodlarını yazarız herşey geçerliyse mesela o zaman kullanıcı role kaydedilir ya da sınıf kaydedilir
    //yönetimin belirlediği kurallar iş kurallarıdır. yapısal olanlar ise validation ile ilgilidir.
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

      //  [SecuredUserOperation("userOperationClaim.add,admin, editor")]        
       // [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {

                        
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult("Kullanıcı rolü" + Messages.Addeding);
        }

        public IResult Delete(int Id)
        {
            var role = _userOperationClaimDal.Get(s => s.Id == Id);
            if (role != null)
            {
                _userOperationClaimDal.Delete(role);
                return new SuccessResult("Kullanıcı rolü" + Messages.Deleteding);
            }
            return new ErrorResult("Silinecek kullanıcı rol" + Messages.NotFound);
        }
    
        //[CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
           
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), "Kullanıcı rolleri" + Messages.Listing);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<UserOperationClaim> GetById(int userOperationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(s => s.Id == userOperationClaimId), "Kullanıcı rolü" + Messages.Listing);
        }


        //[CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var role = _userOperationClaimDal.Get(s => s.Id == userOperationClaim.Id);
            if (role!= null)
            {
                role.OperationClaimId = userOperationClaim.OperationClaimId;
                role.UserId = userOperationClaim.UserId;
                _userOperationClaimDal.Update(role);
                return new SuccessResult("Kullanıcı rolü" + Messages.Updated);
            }
            return new ErrorResult("Güncellenecek kullanıcı rolü" + Messages.NotFound);

        }

    }
}
