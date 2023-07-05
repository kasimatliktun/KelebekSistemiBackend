using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.FileHelper;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //loglama yapılacağı zaman Ilogger isteyince filelog versin de burada diyebiliriz.
            builder.RegisterType<StudentManager>().As<IStudentService>().SingleInstance();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>().SingleInstance();

            builder.RegisterType<ClassroomManager>().As<IClassroomService>().SingleInstance();
            builder.RegisterType<EfClassroomDal>().As<IClassroomDal>().SingleInstance();

            builder.RegisterType<SalonManager>().As<ISalonService>().SingleInstance();
            builder.RegisterType<EfSalonDal>().As<ISalonDal>().SingleInstance();

            builder.RegisterType<DagitimManager>().As<IDagitimService>().SingleInstance();
            builder.RegisterType<EfDagitimDal>().As<IDagitimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<ExamManager>().As<IExamService>().SingleInstance();
            builder.RegisterType<EfExamDal>().As<IExamDal>().SingleInstance();

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            builder.RegisterType<SalonManager>().As<ISalonService>().SingleInstance();
            builder.RegisterType<EfSalonDal>().As<ISalonDal>().SingleInstance();

            builder.RegisterType<StudentImageManager>().As<IStudentImageService>().SingleInstance();
            builder.RegisterType<EfStudentImageDal>().As<IStudentImageDal>().SingleInstance();

            builder.RegisterType<FileHeplerManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();                       

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//adamın aspecti var mı ona bak diyor
                }).SingleInstance();

        }
    }
}
