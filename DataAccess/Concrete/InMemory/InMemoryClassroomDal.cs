using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.inMemory
{
    public class InMemoryClassroomDal : IClassroomDal
    {
        List<Classroom> _classrooms;
        public InMemoryClassroomDal()
        {
            _classrooms = new List<Classroom> { 
            new Classroom{Id=1, Name="9-A",Abbreviation="9-A", Declaration="9-A sınıfıdır."},
            new Classroom{Id=2, Name="9-B",Abbreviation="9-B", Declaration="9-B sınıfıdır."},
            new Classroom{Id=3, Name="10-A",Abbreviation="10-A", Declaration="10-A sınıfıdır."},
            new Classroom{Id=4, Name="10-B",Abbreviation="10-B", Declaration="10-B sınıfıdır."},            

            };
        }
        public void Add(Classroom classroom)
        {
            _classrooms.Add(classroom);
        }

        public void Delete(Classroom classroom)
        {
            Classroom classroomToDelete = _classrooms.SingleOrDefault(c =>c.Id== classroom.Id);
            _classrooms.Remove(classroomToDelete);
        }

        public Classroom Get(Expression<Func<Classroom, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Classroom> GetAll()
        {
            return _classrooms;
        }

        public List<Classroom> GetAll(Expression<Func<Classroom, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Classroom classroom)
        {
            Classroom classroomToUpdate = _classrooms.SingleOrDefault(s => s.Id == classroom.Id);            
            classroomToUpdate.Name = classroom.Name;
            classroomToUpdate.Abbreviation = classroom.Abbreviation;
            classroomToUpdate.Declaration = classroom.Declaration;
        }
    }
}
