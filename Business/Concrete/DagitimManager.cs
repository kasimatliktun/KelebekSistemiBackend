using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class DagitimManager : IDagitimService
    {
        IDagitimDal _dagitimDal;        
        public DagitimManager(IDagitimDal dagitimDal)
        {
            _dagitimDal = dagitimDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(DagitimValidator))]
        public IResult Add(Dagitim dagitim)
        {
            _dagitimDal.Add(dagitim);
            return new SuccessResult("Dağıtım" + Messages.Addeding);
        }

        [SecuredOperation("admin,teacher")]
        public IDataResult<List<Dagitim>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? bunlar buraya gelecektir.            
            return new SuccessDataResult<List<Dagitim>>(_dagitimDal.GetAll(), "Dağıtım" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher")]
        public IDataResult<List<Dagitim>> GetByExamId(int examId)
        {         
            return new SuccessDataResult<List<Dagitim>>(_dagitimDal.GetAll(d => d.ExamId == examId), "Dağıtım" + Messages.Listing);
        }
        [SecuredOperation("admin,teacher")]
        public IDataResult<List<Dagitim>> GetByStudentId(int StdntId)
        {
            return new SuccessDataResult<List<Dagitim>>(_dagitimDal.GetAll(d => d.StdntId == StdntId), "Dağıtım" + Messages.Listing);
        }
        
        [SecuredOperation("admin,teacher,student")]
        public IDataResult<Dagitim> GetByExamIdStudentId(int examId, int studentId)
        {
            return new SuccessDataResult<Dagitim>(_dagitimDal.Get(d => d.ExamId == examId && d.StdntId==studentId), "Öğrenci" + Messages.Listing);
            
        }

        //[SecuredOperation("admin,teacher")]
        public IDataResult<List<Dagitim>> GetByExamIdSalonId(int examId, int salonId)
        {
            return new SuccessDataResult<List<Dagitim>>(_dagitimDal.GetAll(d => d.ExamId == examId && d.SalonId == salonId), "Salon" + Messages.Listing);

        }

        [SecuredOperation("admin,teacher")]
        public IDataResult<List<DagitimDetailDto>> GetDagitimDetails()
        {            
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(), "Dağıtım" + Messages.Listing);
        }
       
        [SecuredOperation("admin,teacher")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoExamId(int examId)
        {
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.ExamId == examId), "Dağıtım" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoStudentId(int studentId)
        {
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.StdntNo  == studentId), "Dağıtım" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoDateSalonId(int salonId)
        {
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => ((d.ExamDay.Hour - DateTime.Now.Hour - 3) * 60 + (d.ExamDay.Minute - DateTime.Now.Minute)) < 60 && ((d.ExamDay.Hour - DateTime.Now.Hour - 3) * 60 + (d.ExamDay.Minute - DateTime.Now.Minute)) > -15 && d.ExamDay.Date == DateTime.Now.Date && d.SalonId == salonId), "Dağıtım" + Messages.Listing);
            //return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.ExamId == examId && d.SalonId == salonId), "Salon" + Messages.Listing);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoExamIdSalonId(int examId, int salonId)
        {            
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.ExamId == examId && d.SalonId == salonId), "Salon" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher,baskan")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoDateClassId(int classId)
        {
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => ((d.ExamDay.Hour - DateTime.Now.Hour - 3) * 60 + (d.ExamDay.Minute - DateTime.Now.Minute)) < 60 && ((d.ExamDay.Hour - DateTime.Now.Hour - 3) * 60 + (d.ExamDay.Minute - DateTime.Now.Minute)) > -15 && d.ExamDay.Date == DateTime.Now.Date && d.ClassId == classId), "Dağıtım" + Messages.Listing);
            //return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.ExamId == examId && d.ClassId == classId), "Dağıtım" + Messages.Listing);
        }
        [SecuredOperation("admin")]
        public IDataResult<List<DagitimDetailDto>> GetByDtoExamIdClassId(int examId, int classId)
        {
            return new SuccessDataResult<List<DagitimDetailDto>>(_dagitimDal.GetDagitimDetails(d => d.ExamId == examId && d.ClassId == classId), "Dağıtım" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher,student")]
        public IDataResult<DagitimDetailDto> GetByDtoExamIdStudentId(int examId, int studentId)
        {
            return new SuccessDataResult<DagitimDetailDto>(_dagitimDal.GetDagitimDetail(d => d.ExamId == examId && d.StdntNo == studentId), "Dağıtım" + Messages.Listing);
        }

        [SecuredOperation("admin,teacher,student")]
        public IDataResult<DagitimDetailDto> GetByDtoDateStudentId(int studentId)
        {
            return new SuccessDataResult<DagitimDetailDto>(_dagitimDal.GetDagitimDetail(d => ((d.ExamDay.Hour - DateTime.Now.Hour - 3)*60 + (d.ExamDay.Minute - DateTime.Now.Minute)) < 60 && ((d.ExamDay.Hour - DateTime.Now.Hour - 3) * 60 + (d.ExamDay.Minute - DateTime.Now.Minute)) > -15  && d.ExamDay.Date == DateTime.Now.Date && d.StdntNo == studentId), "Dağıtım" + Messages.Listing + DateTime.Now);
            //return new SuccessDataResult<DagitimDetailDto>(_dagitimDal.GetDagitimDetail(d => d.ExamDay.Subtract(DateTime.Now).TotalMinutes < 50 && d.StdntNo == studentId), "Dağıtım" + Messages.Listing + DateTime.Now);

        }

    }
    

}
