using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DagitimsController : ControllerBase
    {
        private IDagitimService _dagitimService;

        public DagitimsController(IDagitimService dagitimService)
        {
            _dagitimService = dagitimService;
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dagitimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbyexamid")]
        public IActionResult GetByExamId(int examId)
        {
            var result = _dagitimService.GetByExamId(examId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbystudentid")]
        public IActionResult GetByStudentId(int stdId)
        {
            var result = _dagitimService.GetByStudentId(stdId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher,student")]
        [HttpGet("getbyexamidstudentid")]
        public IActionResult GetByExamIdStudentId(int examId, int stdId)
        {
            var result = _dagitimService.GetByExamIdStudentId(examId, stdId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbyexamidsalonid")]
        public IActionResult GetByExamIdSalonId(int examId, int salonId)
        {
            var result = _dagitimService.GetByExamIdSalonId(examId, salonId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbydatesalonid")]
        public IActionResult GetByDtoDateSalonId(int salonId)
        {
            var result = _dagitimService.GetByDtoDateSalonId(salonId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getdagitimdetails")]
        public IActionResult GetDagitimDetails()
        {
            var result = _dagitimService.GetDagitimDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbydtoexamid")]
        public IActionResult GetByDtoExamId(int examId)
        {
            var result = _dagitimService.GetByDtoExamId(examId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Authorize(Roles = "admin,teacher")]
        [HttpGet("getbydtostudentid")]
        public IActionResult GetByDtoStudentId(int stdId)
        {
            var result = _dagitimService.GetByDtoStudentId(stdId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,teacher,baskan")]
        [HttpGet("getbydtoexamidclassid")]
        public IActionResult GetByDtoExamIdClassId(int examId, int classId)
        {
            var result = _dagitimService.GetByDtoExamIdClassId(examId, classId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydtodateclassid")]
        public IActionResult GetByDtoDateClassId(int classId)
        {
            var result = _dagitimService.GetByDtoDateClassId(classId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,teacher")]
        [HttpGet("getbydtoexamidsalonid")]
        public IActionResult GetByDtoExamIdSalonId(int examId, int salonId)
        {
            var result = _dagitimService.GetByDtoExamIdSalonId(examId, salonId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,teacher,student")]
        [HttpGet("getbydtoexamidstudentid")]
        public IActionResult GetByDtoExamIdStudentId(int examId, int stdId)
        {
            var result = _dagitimService.GetByDtoExamIdStudentId(examId, stdId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[Authorize(Roles = "admin,teacher,student")]
        [HttpGet("getbydtodatestudentid")]
        public IActionResult GetByDtoDateStudentId( int stdId)
        {
            var result = _dagitimService.GetByDtoDateStudentId(stdId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
