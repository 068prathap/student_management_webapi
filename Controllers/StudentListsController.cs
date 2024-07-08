using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTWebApi.Data;
using JWTWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Immutable;

namespace JWTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class StudentListsController : ControllerBase
    {
        private readonly SchoolMgmtContext _context;

        public StudentListsController(SchoolMgmtContext context)
        {
            _context = context;
        }

        // GET: api/StudentLists
        [HttpGet]
        [Route("/getAllStudents")]
        //[Authorize]
        public async Task<ActionResult<StudentList>> GetAllStudentList(int schoolId)
        {
            try
            {
                var studentList = await _context.StudentList.Where(r => r.schoolId == schoolId).ToListAsync();
                return Ok(studentList);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // GET: api/StudentLists/5
        [HttpGet("/getStudentDetails/{id}")]
        //[Authorize]
        public async Task<ActionResult<StudentList>> GetStudentDetails(int schoolId, int id)
        {
            try
            {
                var studentList = await _context.StudentList.Where(r => (r.schoolId == schoolId && r.studentId == id)).ToListAsync();
                return Ok(studentList);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // PUT: api/StudentLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/editStudentDetails/{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> PutStudentList(int schoolId, int id, StudentList studentList)
        {
            if (id != studentList.studentId)
            {
                return BadRequest();
            }

            _context.Entry(studentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("successfully edited");
        }

        // POST: api/StudentLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/addStudent")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<StudentList>> PostStudentList(StudentList studentList)
        {
            try
            {
                _context.StudentList.Add(studentList);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStudentDetails", new { id = studentList.rollNo }, studentList);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        // DELETE: api/StudentLists/5
        [HttpDelete("/deleteStudent/{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteStudentList(int id)
        {
            try
            {
                var studentList = await _context.StudentList.FindAsync(id);
                if (studentList == null)
                {
                    return NotFound();
                }

                _context.StudentList.Remove(studentList);
                await _context.SaveChangesAsync();

                return Ok("successfully deleted");
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        private bool StudentListExists(int id)
        {
            return _context.StudentList.Any(e => e.rollNo == id);
        }
    }
}