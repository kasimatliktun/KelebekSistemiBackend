using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentImagesController : ControllerBase
    {
        IStudentImageService _studentImageService;
        public StudentImagesController(IStudentImageService studentImageService)
        {
            _studentImageService = studentImageService;
        }
        [HttpPost("add")]
        public IActionResult Add( IFormFile file, int studentId)
        {
            var result = _studentImageService.Add(file, studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _studentImageService.Delete(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("update")]

        public IActionResult Update(int id, IFormFile file)
        {
            var result = _studentImageService.Update(file, id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _studentImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbystudentid")]
        public IActionResult GetByStudentId(int studentId)
        {
            var result = _studentImageService.GetByStudentId(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = _studentImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
