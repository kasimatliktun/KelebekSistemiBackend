using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private ISalonService _salonService;

        public SalonsController(ISalonService salonService)
        {
            _salonService = salonService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _salonService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
