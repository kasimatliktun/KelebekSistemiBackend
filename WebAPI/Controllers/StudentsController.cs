using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "admin,teacher")]
        public IActionResult GetAll()
        {            
            var result = _studentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _studentService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher,baskan")]
        [HttpGet("getbyclass")]
        public IActionResult GetByClass(int id)
        {
            var result = _studentService.GetAllByClassroomId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            var result = _studentService.Add(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int Id)
        {
            var result = _studentService.Delete(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
