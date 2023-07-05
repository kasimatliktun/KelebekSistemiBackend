using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentImageManager : IStudentImageService
    {
        IStudentImageDal _studentImageDal;
        IFileHelper _fileHelper;        
        string _defaultImagePath = "Uploads/images/default.jpg";
        public StudentImageManager(IStudentImageDal studentImageDal, IFileHelper fileHelper)
        {
            _studentImageDal = studentImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, int studentId)
        {
            IResult result = BusinessRules.Run(CheckIfStudentImageLimit(studentId));
            if (result != null)
            {
                return result;
            }
            var studentImage = new StudentImage

            {
                StudentId = studentId,
                Date = DateTime.Now,
                ImagePath = _fileHelper.Upload(file)
            };

            _studentImageDal.Add(studentImage);

            return new SuccessResult(Messages.StudentImageAdded);

        }

        public IResult Update(IFormFile file, int id)
        {            
            var studentImage = _studentImageDal.Get(s => s.Id == id);
            studentImage.ImagePath = _fileHelper.Update(file, studentImage.ImagePath);

            _studentImageDal.Update(studentImage);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(int id)
        {
            var studentImage = _studentImageDal.Get(s => s.Id == id);
            _fileHelper.Delete(studentImage.ImagePath);           
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<StudentImage>> GetAll()
        {
            return new SuccessDataResult<List<StudentImage>>(_studentImageDal.GetAll());
        }

        public IDataResult<StudentImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<StudentImage>(_studentImageDal.Get(c => c.Id == imageId), Messages.Listed);
        }

        public IDataResult<List<StudentImage>> GetByStudentId(int studentId)
        {
            var result = BusinessRules.Run(CheckStudentImage(studentId));
            if (result != null)
            {
                return new ErrorDataResult<List<StudentImage>>(GetDefaultImage(studentId).Data);
            }
            return new SuccessDataResult<List<StudentImage>>(_studentImageDal.GetAll(c => c.StudentId == studentId), Messages.Listed);
        }

      

        private IResult CheckIfStudentImageLimit(int studentId)
        {
            var result = _studentImageDal.GetAll(c => c.StudentId == studentId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitHasBeenExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<StudentImage>> GetDefaultImage(int studentId)
        {

            List<StudentImage> studentImage = new List<StudentImage>();
            studentImage.Add(new StudentImage { StudentId = studentId, Date = DateTime.Now, ImagePath = _defaultImagePath });
            return new SuccessDataResult<List<StudentImage>>(studentImage);
        }
        private IResult CheckStudentImage(int studentId)
        {
            var result = _studentImageDal.GetAll(c => c.StudentId == studentId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
