using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
//using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.inMemory
{
    public class InMemoryStudentDal : IStudentDal
    {
        List<Student> _students;
        public InMemoryStudentDal()
        {
            _students = new List<Student> { 
            new Student{Id=1, Name ="Ahmet Alagöz", ClassId=1,  Gender="Erkek"},
            new Student{Id=2, Name="Hatice Duran",ClassId=1, Gender="Kız"},
            new Student{Id=3, Name="Kamil Adalı",ClassId=2,  Gender="Erkek"},
            new Student{Id=4, Name="Sait Şeker",ClassId=1,  Gender="Erkek"},

            };
        }
        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Delete(Student student)
        {
            Student studentToDelete = _students.SingleOrDefault(s => s.Id == student.Id);
            _students.Remove(studentToDelete);
        }

        public Student Get(Expression<Func<Student, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public List<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

               
        public List<StudentDetailDto> GetStudentDetails()
        {
            throw new NotImplementedException();
        }


        public void Update(Student student)
        {
            Student studentToUpdate = _students.SingleOrDefault(s => s.Id == student.Id);            
            studentToUpdate.Gender = student.Gender;
            studentToUpdate.Name  = student.Name;            
            studentToUpdate.ClassId = student.ClassId;
            
        }
    }
}
