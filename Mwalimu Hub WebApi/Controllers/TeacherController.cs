using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_WebApi.Helper;
using Mwalimu_Hub_WebApi.Models;
using Mwalimu_Hub_WebApi.ServiceErrors;
using Mwalimu_Hub_WebApi.Services.TeacherService;
using MwalimuHub.Contracts.Teacher;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static Mwalimu_Hub_WebApi.Controllers.AuthenticationController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ApiController
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("SaveAttendance")]
        public IActionResult SaveAttendance(Attendance response)
        {
            var attendance = new Attendance(response.Id,response.ScheduleId,response.Day,response.Time,response.StudentNo,response.Status);
            //save to database
            _teacherService.SaveAttendance(attendance);
           return Ok();
        }

        [HttpGet("SingleTeacher/{id}")]
        public IActionResult GetTeacher(int id)
        {
            
            ErrorOr<DataTable> getDataTableTeacherResult = _teacherService.GetTeacher(id);
            if(getDataTableTeacherResult.IsError && getDataTableTeacherResult.FirstError == Errors.TeacherS.NotFound)
            {
                return NotFound();
            }
            var dataTableTeacher = getDataTableTeacherResult.Value;
            foreach (DataRow row in dataTableTeacher.Rows)
            {
                var response = new TeacherResponse(int.Parse(row["id"].ToString()), row["forename"].ToString(),
                 row["surname"].ToString(), int.Parse(row["idNumber"].ToString()),
                 row["phonenumber"].ToString(), row["tscnumber"].ToString(), row["department"].ToString(),
                 row["employer"].ToString(), row["EmployementType"].ToString());
                return Ok(response);
            }
            return Ok();

         
            
        }
        

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _teacherService.DeleteTeacher(id);
        }
        //public bool CheckNulls()
        //{

        //}
    }
}
