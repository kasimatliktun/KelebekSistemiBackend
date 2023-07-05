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
    public interface IStudentService
    {
        IDataResult<List<Student>> GetAll();
        IDataResult<List<Student>> GetAllByClassroomId(int Id);
        IDataResult<Student> GetById(int studentId);
        IDataResult<List<StudentDetailDto>> GetStudentDetails();

        IResult Add(Student student);
        IResult Update(Student student);
        IResult Delete(int Id);
        IResult AddTransactionalTest(Student student);
    }
}
