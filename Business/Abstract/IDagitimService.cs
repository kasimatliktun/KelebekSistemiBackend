using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDagitimService
    {
        IDataResult<List<Dagitim>> GetAll();
        //Dagitim GetById(int Id);        
        IDataResult<List<Dagitim>> GetByExamId(int Id);
        IDataResult<List<Dagitim>> GetByStudentId(int studentId);
        IDataResult<Dagitim> GetByExamIdStudentId(int examId, int studentId);
        IDataResult<List<Dagitim>> GetByExamIdSalonId(int examId, int salonId);              
        IResult Add(Dagitim dagitim);


        IDataResult<List<DagitimDetailDto>> GetDagitimDetails();
        IDataResult<List<DagitimDetailDto>> GetByDtoExamId(int Id);
        IDataResult<List<DagitimDetailDto>> GetByDtoStudentId(int studentId);       
        IDataResult<List<DagitimDetailDto>> GetByDtoExamIdSalonId(int examId, int salonId);
        IDataResult<List<DagitimDetailDto>> GetByDtoExamIdClassId(int examId, int classId);
        IDataResult<List<DagitimDetailDto>> GetByDtoDateSalonId(int salonId);
        IDataResult<List<DagitimDetailDto>> GetByDtoDateClassId(int classId);
        IDataResult<DagitimDetailDto> GetByDtoExamIdStudentId(int examId, int studentId);
        IDataResult<DagitimDetailDto> GetByDtoDateStudentId(int studentId);


    }
}
