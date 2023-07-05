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
    public class InMemoryLessonDal : ILessonDal
    {
        List<Lesson> _lessons;
        public InMemoryLessonDal()
        {
            _lessons = new List<Lesson> { 
            new Lesson{Id=1, Name="Matematik",Abbreviation="MAT", Declaration="Matematik Dersi geometri de dahildir.", Duration=6},
            new Lesson{Id=2, Name="Türkçe",Abbreviation="TRK", Declaration="Türkçe Dersi geometri de dahildir.", Duration=6},
            new Lesson{Id=3, Name="Fizik",Abbreviation="FZK", Declaration="Fizik Dersi geometri de dahildir.", Duration=3},
            new Lesson{Id=4, Name="Kimya",Abbreviation="KMY", Declaration="Kimay Dersi geometri de dahildir.", Duration=2},            

            };
        }
        public void Add(Lesson lesson)
        {
            _lessons.Add(lesson);
        }

        public void Delete(Lesson lesson)
        {
            Lesson lessonToDelete = _lessons.SingleOrDefault(l =>l.Id== lesson.Id);
            _lessons.Remove(lessonToDelete);
        }

        public Lesson Get(Expression<Func<Lesson, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Lesson> GetAll()
        {
            return _lessons;
        }

        public List<Lesson> GetAll(Expression<Func<Lesson, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Lesson lesson)
        {
            Lesson lessonToUpdate = _lessons.SingleOrDefault(s => s.Id == lesson.Id);
            lessonToUpdate.Abbreviation = lesson.Abbreviation;
            lessonToUpdate.Declaration = lesson.Declaration;
            lessonToUpdate.Name = lesson.Name;
            lessonToUpdate.Duration = lesson.Duration;            
        }
    }
}
