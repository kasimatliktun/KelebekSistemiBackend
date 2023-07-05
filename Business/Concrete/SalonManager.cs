using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SalonManager : ISalonService
    {
        ISalonDal _salonDal;

        public SalonManager(ISalonDal salonDal)
        {
            _salonDal = salonDal;
        }

        [ValidationAspect(typeof(SalonValidator))]
        public IResult Add(Salon salon)
        {           

            _salonDal.Add(salon);
            return new SuccessResult("Salon" + Messages.Addeding);
        }

        //iş kurallarını aşağıda yazıyoruz
  

        public IDataResult<List<Salon>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<Salon>>(_salonDal.GetAll(), "Salonlar" + Messages.Listing);
        }
    }
}
