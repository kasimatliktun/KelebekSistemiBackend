using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ButterflyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ButterYedek;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ButterflySystem;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=tcp:butterflysql.database.windows.net,1433;Initial Catalog=ButterFlySystem;Persist Security Info=False;User ID=butteradmin;Password=19ffffffF.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Dagitim> Dagitims { get; set; }
        //public DbSet<DenemeDagit> DenemeDagits { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Salon> Salons { get; set; }
        
        //Aşağısı kullanıcı işlemleri için
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<StudentImage> StudentImages { get; set; }
    }
}
