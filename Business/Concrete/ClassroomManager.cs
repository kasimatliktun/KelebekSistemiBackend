using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClassroomManager : IClassroomService
    {
        IClassroomDal _classroomDal;

        public ClassroomManager(IClassroomDal classroomDal)
        {
            _classroomDal = classroomDal;
        }

        [ValidationAspect(typeof(ClassroomValidator))]
        public IResult Add(Classroom classroom)
        {
            _classroomDal.Add(classroom);
            return new SuccessResult("Sınıf" + Messages.Addeding);
        }

        public IDataResult<List<Classroom>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<Classroom>>(_classroomDal.GetAll(), "Sınıflar" + Messages.Listing);
        }

        public IDataResult<Classroom> GetById(int Id)
        {            
            return new SuccessDataResult<Classroom>(_classroomDal.Get(c => c.Id == Id), "Sınıflar" + Messages.Listing);
        }
    }
}
