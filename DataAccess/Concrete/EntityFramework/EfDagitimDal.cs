using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDagitimDal : EfEntityRepositoryBase<Dagitim, ButterflyContext>, IDagitimDal
    {
        public DagitimDetailDto GetDagitimDetail(Expression<Func<DagitimDetailDto, bool>> filter )
        {
            using (var context = new ButterflyContext())
            {
                var result = from d in context.Dagitims
                             join s in context.Students
                             on d.StdntId equals s.Id

                             join sl in context.Salons
                             on d.SalonId equals sl.Id

                             join e in context.Exams
                             on d.ExamId equals e.Id

                             join si in context.StudentImages
                             on s.Id equals si.StudentId

                             join c in context.Classrooms
                             on s.ClassId equals c.Id

                             select new DagitimDetailDto
                             {
                                 DagitimId = d.Id,
                                 ExamDay = e.Dates,
                                 StdntNo = s.Id,
                                 StdntName = s.Name,
                                 ClassId = c.Id,
                                 StdntClass = c.Name,
                                 SalonId = sl.Id,
                                 SalonName = sl.Name,
                                 Image = si.ImagePath,
                                 ExamId = e.Id,
                                 ExamName = e.Name,
                                 Yer = d.Yer
                             };
                //return result.ToList();
                return result.SingleOrDefault(filter);

            }
        }

        public List<DagitimDetailDto> GetDagitimDetails(Expression<Func<DagitimDetailDto, bool>> filter = null)
        {
            using (var context = new ButterflyContext())
            {
                var result = from d in context.Dagitims
                             join s in context.Students
                             on d.StdntId equals s.Id

                             join sl in context.Salons
                             on d.SalonId equals sl.Id

                             join e in context.Exams
                             on d.ExamId equals e.Id

                             join c in context.Classrooms
                             on s.ClassId equals c.Id

                             select new DagitimDetailDto
                             {
                                 DagitimId = d.Id,
                                 ExamDay = e.Dates,
                                 StdntNo = s.Id,
                                 StdntName = s.Name,
                                 ClassId = c.Id,
                                 StdntClass = c.Name,
                                 SalonId =sl.Id,
                                 SalonName = sl.Name,
                                 ExamId = e.Id,
                                 ExamName = e.Name,                                 
                                 Yer = d.Yer
                             };
                //return result.ToList();
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).OrderBy(c => c.StdntNo).ToList();

            }
        }
    }
}
