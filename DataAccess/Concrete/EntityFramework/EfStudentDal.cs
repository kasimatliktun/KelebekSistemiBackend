using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, ButterflyContext>, IStudentDal
    {
       public List<StudentDetailDto> GetStudentDetails()
        {
            using (var context = new ButterflyContext())
            {
                var result = from s in context.Students
                             join c in context.Classrooms
                             on s.ClassId equals c.Id
                             select new StudentDetailDto
                             {
                                 StudentId = s.Id,
                                 StudentName = s.Name,
                                 ClassroomName = c.Name,
                                 Gender = s.Gender,
                                 Image = s.Image,
                             };
                return result.ToList();

            }
        }
    }
}
