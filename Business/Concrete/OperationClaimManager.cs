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
    //buraya iş kodlarını yazarız herşey geçerliyse mesela o zaman role kaydedilir ya da sınıf kaydedilir
    //yönetimin belirlediği kurallar iş kurallarıdır. yapısal olanlar ise validation ile ilgilidir.
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

      [SecuredOperation("operationClaim.add,admin, editor")]        
       [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Add(OperationClaim operationClaim)
        {

                        
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult("Rol" + Messages.Addeding);
        }

        public IResult Delete(int Id)
        {
            var role = _operationClaimDal.Get(s => s.Id == Id);
            if (role != null)
            {
                _operationClaimDal.Delete(role);
                return new SuccessResult("Rol" + Messages.Deleteding);
            }
            return new ErrorResult("Silinecek rol" + Messages.NotFound);
        }
    
        //[CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
           
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), "Roller" + Messages.Listing);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<OperationClaim> GetById(int operationClaimId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(s => s.Id == operationClaimId), "Rol" + Messages.Listing);
        }


        //[CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Update(OperationClaim operationClaim)
        {
            var role = _operationClaimDal.Get(s => s.Id == operationClaim.Id);
            if (role != null)
            {
                role .Name=operationClaim.Name;
                _operationClaimDal.Update(role);
                return new SuccessResult("Rol" + Messages.Updated);
            }
            return new ErrorResult("Güncellenecek rol" + Messages.NotFound);

        }

    }
}
