using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_WebApi.Helper;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost("CreateNewTeacher")]
        public IActionResult CreateTeacher([FromBody] Teacher teacher)
        {

            if (teacher.Forename == string.Empty || teacher.Surname == string.Empty || teacher.PhoneNumber == string.Empty || teacher.Employer == string.Empty || teacher.EmployerType == string.Empty || teacher.Department == string.Empty || teacher.Password == string.Empty)
            {
               return BadRequest("Only Tsc number can be empty");
                

            }
            if (!Regex.Match(teacher.Forename, "^[a-zA-Z]*$").Success || teacher.Forename.Length > 100)
            {
                return BadRequest("Invalid Forename.");
                
            }
            if (!Regex.Match(teacher.Surname, "^[a-zA-Z]*$").Success || teacher.Surname.Length > 50)
            {
                return BadRequest($"Invalid Surname.");
                
            }
            if (!Regex.Match(teacher.IdNumber.ToString(), "^[0-9]*$").Success || teacher.IdNumber.ToString().Length > 9 || teacher.IdNumber.ToString().Length < 6)
            {
                return BadRequest("Invalid Id Number.");
                
            }

            if (!Regex.Match(teacher.PhoneNumber, "^[0-9]*$").Success || teacher.PhoneNumber.Length > 20 || teacher.PhoneNumber.Length < 10)
            {
                return BadRequest("Invalid Phone Number.");
               
            }

            else
            {
                if (teacher.TscNumber.Length > 20 || !Regex.Match(teacher.TscNumber, "^[0-9+]*$").Success)
                {
                    return BadRequest("Invalid TSC Number.");
                    
                }
                if (teacher.TscNumber == string.Empty)
                {
                    teacher.TscNumber = "0";
                }
                bool teacherCreated = TeacherHelper.CreateTeacher(teacher);
                if (teacherCreated)
                {
                    return Ok("Teacher added successfully");
                }
                else
                {
                    return BadRequest("Teacher already exist");
                }

            }
        }
        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
