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
using System.Data;

namespace Business.Concrete
{
    //buraya iş kodlarını yazarız herşey geçerliyse mesela o zaman öğrenci kaydedilir ya da sınıf kaydedilir
    //yönetimin belirlediği kurallar iş kurallarıdır. yapısal olanlar ise validation ile ilgilidir.
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        [SecuredOperation("student.add,admin, editor")]
        [ValidationAspect(typeof(StudentValidator))]
        [CacheRemoveAspect("IStudentService.Get")]
        public IResult Add(Student student)
        {

            IResult result = BusinessRules.Run(CheckIfStudentNameExists(student.Name));//yeni kural gelirse aşağıya ekle ve buraya , ile ekle bu kadar

            if (result != null)
            {
                return result;
            }
            student.Image = "~/DataAccess/Images/" + student.Id + ".jpg";
            //student.Image = student.Id + ".jpg";
            _studentDal.Add(student);
            return new SuccessResult("Öğrenci" + Messages.Addeding);
        }

        public IResult Delete(int Id)
        {
            var ogrenci = _studentDal.Get(s => s.Id == Id);
            if (ogrenci != null)
            {
                _studentDal.Delete(ogrenci);
                return new SuccessResult("Öğrenci" + Messages.Deleteding);
            }
            return new ErrorResult("Silinecek öğrenci" + Messages.NotFound);
        }
    

        //iş kurallarını aşağıda yazıyoruz
        private IResult[] CheckIfStudentNameExists(object studentName)
        {
            var result = _studentDal.Get(s => s.Name == studentName);
            if (result != null)
            {
                return new IResult[] { new ErrorResult("Öğrenci" + Messages.NameAlreadyExists) };
            }
            return new IResult[] { new SuccessResult() };                        
        }

        [CacheAspect]
        public IDataResult<List<Student>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(), "Öğrenciler" + Messages.Listing);
        }

        public IDataResult<List<Student>> GetAllByClassroomId(int Id)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(s=>s.ClassId ==Id), "Öğrenciler" + Messages.Listing);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Student> GetById(int studentId)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(s => s.Id == studentId), "Öğrenci" + Messages.Listing);
        }

        public IDataResult<List<StudentDetailDto>> GetStudentDetails()
        {
            return new SuccessDataResult<List<StudentDetailDto>>(_studentDal.GetStudentDetails(), "Öğrenciler" + Messages.Listing);
        }

        [CacheRemoveAspect("IStudentService.Get")]
        public IResult Update(Student student)
        {
            var ogrenci = _studentDal.Get(s => s.Id == student.Id);
            if (ogrenci != null)
            {
                ogrenci.Name = student.Name;
                ogrenci.Gender = student.Gender;
                ogrenci.ClassId = student.ClassId;
                ogrenci.Image = student.Image;
                _studentDal.Update(ogrenci);
                return new SuccessResult("Öğrenci" + Messages.Updated);
            }
            return new ErrorResult("Güncellenecek öğrenci" + Messages.NotFound);

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Student student)
        {
            Add(student);
            if (student.Id < 1)
            {
                throw new Exception("");
            }

            Add(student);

            return null;

        }
    }
}
