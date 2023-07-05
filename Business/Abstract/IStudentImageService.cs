using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentImageService
    {
        IResult Add(IFormFile file, int studentId);
        IResult Delete(int id);
        IResult Update(IFormFile file, int id);

        IDataResult<List<StudentImage>> GetAll();
        IDataResult<List<StudentImage>> GetByStudentId(int studentImage);
        IDataResult<StudentImage> GetByImageId(int imageId);
    }
}
