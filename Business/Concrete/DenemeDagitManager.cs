using Business.Abstract;
using Business.Constants;
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
    public class DenemeDagitManager : IDenemeDagitService
    {
        IDenemeDagitDal _denemeDagitDal;

        public DenemeDagitManager(IDenemeDagitDal denemeDagitDal)
        {
            _denemeDagitDal = denemeDagitDal;
        }

        public IDataResult<List<DenemeDagit>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<DenemeDagit>>(_denemeDagitDal.GetAll(), "Dağıtım" + Messages.Listing);
        }


    }
}
