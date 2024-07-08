using JWTWebApi.Data;
using JWTWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JWTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly SchoolMgmtContext context;
        public RegisterController(SchoolMgmtContext context)
        {
            this.context=context;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterSchool(SchoolDetails schoolDetails)
        {
            try
            {
                if (userNameCheck(schoolDetails.userName))
                {
                    return BadRequest("userName already exists");
                }
                else if (emailCheck(schoolDetails.email))
                {
                    return BadRequest("email already exists");
                }
                context.SchoolDetails.Add(schoolDetails);
                await context.SaveChangesAsync();

                return StatusCode(201, "successfully registered");
            }
            catch (Exception error)
            {
                return StatusCode(500,error.Message);
            }
        }

        private bool userNameCheck(string name)
        {
            return context.SchoolDetails.Any(b => b.userName == name);
        }

        private bool emailCheck(string email)
        {
            return context.SchoolDetails.Any(b => b.email == email);
        }
    }
}