using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService; // TEST

        public AuthController(
            IAuthService authService,
            IUserService userService // TEST
            )
        {
            _authService = authService;
            _userService = userService; // TEST
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
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);

            if (userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            //var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            //var result = _authService.CreateAccessToken(registerResult.Data);

            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            var userToAdd = new User
            {
                Email = userForRegisterDto.Email,
                LastName = userForRegisterDto.LastName,
                FirstName = userForRegisterDto.FirstName,
            };

            _userService.Add(userToAdd);

            return Ok();
        }

        // TEST
        [HttpGet("users")]
        public ActionResult GetAllUsers()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }
    }
}
