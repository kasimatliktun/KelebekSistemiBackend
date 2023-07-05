using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private IClassroomService _classroomService;

        public ClassroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _classroomService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
