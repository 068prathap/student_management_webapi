using JWTWebApi.Data;
using JWTWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace JWTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SchoolMgmtContext context;
        private readonly IConfiguration config;
        public LoginController(SchoolMgmtContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        [HttpPost]
        [Route ("/login")]
        public async Task<IActionResult> Login(LoginDetails loginDetails)
        {
            if (LoginCheck(loginDetails.name, loginDetails.password, loginDetails.role))
            {
                var schoolId = FindSchoolId(loginDetails.name);
                var token = TokenGenerate(loginDetails.name,loginDetails.role);

                return Ok(new { schoolId, token });
            }
            else
            {
                return NotFound("their is no school found");
            }
        }

        private bool LoginCheck(string name, string password, string role)
        {
            return context.SchoolDetails.Any(b => (b.userName == name || b.email == name) && role=="admin" ? b.adminPassword == password : b.studentPassword == password);
        }

        private int FindSchoolId(string name)
        {
            var user = context.SchoolDetails.FirstOrDefault(u => u.userName == name || u.email == name);
            return user.schoolId;
        }

        private string TokenGenerate(string name,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("user", name),   // Custom claim 1
                new Claim(ClaimTypes.Role, role)
            };

            var Sectoken = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}