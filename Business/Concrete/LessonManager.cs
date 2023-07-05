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
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;            
        }

        [ValidationAspect(typeof(LessonValidator))]
        public IResult Add(Lesson lesson)
        {
            _lessonDal.Add(lesson);
            return new SuccessResult("Ders" + Messages.Addeding);
        }

        public IDataResult<List<Lesson>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll(), "Dersler" + Messages.Listing);
        }
    }
}
