using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExamManager : IExamService
    {
        IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;            
        }
                
        public IDataResult<List<Exam>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<Exam>>(_examDal.GetAll().OrderBy(e => e.Name).ToList(), "Sınavlar" + Messages.Listing);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ExamValidator))]
        public IResult Add(Exam exam)
        {

            IResult result = BusinessRules.Run(CheckIfStudentNameExists(exam.Name));//yeni kural gelirse aşağıya ekle ve buraya , ile ekle bu kadar

            if (result != null)
            {
                return result;
            }            
            _examDal.Add(exam);
            return new SuccessResult("Sınav" + Messages.Addeding);
        }

        public IResult Delete(int Id)
        {
            var sinav = _examDal.Get(e => e.Id == Id);
            if (sinav != null)
            {
                _examDal.Delete(sinav);
                return new SuccessResult("Sınav" + Messages.Deleteding);
            }
            return new ErrorResult("Silinecek Sınav" + Messages.NotFound);
        }

        public IResult Update(Exam exam)
        {
            var sinav = _examDal.Get(e => e.Id == exam.Id);
            if (sinav != null)
            {
                sinav.Name=exam.Name;
                sinav.Day=exam.Day;
                sinav.DersSaati=exam.DersSaati;
                sinav.Dates = exam.Dates;
                sinav.Declaration = exam.Declaration;
                _examDal.Update(sinav);
                return new SuccessResult("Sınav" + Messages.Updated);
            }
            return new ErrorResult("Silinecek Sınav" + Messages.NotFound);
        }


        //iş kurallarını aşağıda yazıyoruz
        private IResult[] CheckIfStudentNameExists(object studentName)
        {
            var result = _examDal.Get(s => s.Name == studentName);
            if (result != null)
            {
                return new IResult[] { new ErrorResult("Sınav" + Messages.NameAlreadyExists) };
            }
            return new IResult[] { new SuccessResult() };
        }
    }
}
