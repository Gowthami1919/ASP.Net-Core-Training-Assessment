using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCrudOpe.Data;
using MovieCrudOpe.DTOS;
using MovieCrudOpe.Models;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MovieCrudOpe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly DataContext _content;
        public AuthController(IAuthRepository repo, IConfiguration config, DataContext content)
        {
            _repo = repo;
            _config = config;
            _content = content;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegiserDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new UserRegister
            {
                UserName = userForRegisterDto.Username,
                Name = userForRegisterDto.Name,
                Password = userForRegisterDto.Password,
                ConfirmPassword = userForRegisterDto.ConfirmPassword,
                age = userForRegisterDto.Age,
                Gender = userForRegisterDto.Gender,
                phoneNumber = userForRegisterDto.phoneNumber,
                Address = userForRegisterDto.Address

            };

            var createdUser = await _repo.Register(userToCreate);
            return StatusCode(201);
        }

             [HttpPost("login")]
        public async Task<ActionResult> login(UserForLoginDto userForLogindDto)
        {
            try
            {
                throw new Exception("computer says no");


                var userFromRepo = await _repo.Login(userForLogindDto.username, userForLogindDto.password);
                if (userFromRepo == null)
                    return Unauthorized();

                var claim = new[]{
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.UserName)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.
                    GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claim),
                    Expires = DateTime.Now.AddMinutes(10),
                    SigningCredentials = creds,

                };
                var tokenhandler = new JwtSecurityTokenHandler();
                var token = tokenhandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenhandler.WriteToken(token)
                }
                );
            }
            catch
            {
                return StatusCode(500, "computer Really says no !");
            }
        }
        


    }
}
