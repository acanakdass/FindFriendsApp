using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
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

            var createTokenResult = _authService.CreateAccessToken(userToLogin.Data);
            if (createTokenResult.Success)
            {
                var returnDto = new UserLoggedInDto();
                returnDto.Email = userToLogin.Data.Email;
                returnDto.FirstName = userToLogin.Data.FirstName;
                returnDto.LastName = userToLogin.Data.LastName;
                returnDto.Token = createTokenResult.Data.Token;
                returnDto.Expiration= createTokenResult.Data.Expiration.ToString();
                var result = new SuccessDataResult<UserLoggedInDto>(returnDto,Messages.SuccessfulLogin);
                return Ok(result);
            }

            return BadRequest(createTokenResult.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
