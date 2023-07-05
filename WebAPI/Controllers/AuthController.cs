using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            //Aşağıda öğrenci olup olmadığı kontrol ediliyor.
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            // Aşağıda kullanıcıyı kaydettik
            var registerResult = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            // Aşağıda da kaydedilen kullanıcıya token üretiyoruz.
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // Admin rolüne sahip kullanıcılara özel erişim sağlamak için
        public IActionResult GetUserData()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"User Role: {userRole}");

            return Ok(new { UserId = userId, UserRole = userRole });
        }
    }
}
