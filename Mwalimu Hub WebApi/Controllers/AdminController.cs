using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_WebApi.Helper;
using Mwalimu_Hub_WebApi.ServiceErrors;
using Mwalimu_Hub_WebApi.Services.AdminService;
using MwalimuHub.Contracts.Admin;
using MwalimuHub.Contracts.Teacher;
using System.Data;
using System.Text.RegularExpressions;
using XAct.Messages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ApiController
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("CreateNewTeacher")]
        public IActionResult TeacherRegister([FromBody] CreateTeacherRequest request)
        {
            ErrorOr<Teacher> requestToTeacher = Teacher.From(request);
            if (requestToTeacher.IsError)
            {
                return Problem(requestToTeacher.Errors);
            }
            var teacher = requestToTeacher.Value;
            ErrorOr<Created> CreateNewTeacherResult = _adminService.CreateTeacher(teacher);
            return CreateNewTeacherResult.Match(created => Ok(), errors => Problem(errors));
        }


        [HttpGet("allteachers")]
        public IActionResult GetAllTeachers()
        {
            ErrorOr<DataTable> getTeachersResult = _adminService.GetAllTeachers();
            return getTeachersResult.Match(teacher => Ok(MapToTeacherResponse(teacher)), errors => Problem(errors));

        }


        [HttpGet("singleteacher/{id}")]

        public IActionResult GetTeacher(int id)
        {
            ErrorOr<DataTable> getSingleTeacherData = _adminService.GetTeacher(id);
            return getSingleTeacherData.Match(teacher => Ok(MapToTeacherResponse(teacher)), errors => Problem(errors));
        }



        // PUT api/<TeacherController>/5
        [HttpPut("upsertTeacher/{id}")]
        public IActionResult UpsertTeacher(int id, UpsertTeacherRequest request)
        {
            ErrorOr<Teacher> requestToTeacherResult = Teacher.From(id, request);
            if (requestToTeacherResult.IsError)
            {
                return Problem(requestToTeacherResult.Errors);
            }
            var teacher = requestToTeacherResult.Value;
            ErrorOr<Updated> upsertResult = _adminService.UpsertTeacher(teacher);
            return upsertResult.Match(teacher => NoContent(), errors => Problem(errors));

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            ErrorOr<Deleted> deletedResult = _adminService.DeleteTeacher(id);
            return deletedResult.Match(deleted => NoContent(), errors => Problem(errors));
        }
       
        [HttpPost("createAdmin")]
        public IActionResult CreateAdmin(CreateAdminRequest request)
        {
            ErrorOr<AdminS> requestToAdminResult = AdminS.From(request);
            if (requestToAdminResult.IsError)
            {
                return Problem(requestToAdminResult.Errors);
            }
            var admin = requestToAdminResult.Value;
            ErrorOr<Created> CreateAdminResult = _adminService.CreateAdmin(admin);
            return CreateAdminResult.Match(admin => Ok(), errors => Problem(errors));
        }
        [HttpGet("getAllAdmin")]
        public IActionResult GetAllAdmins()
        {
            ErrorOr<DataTable> getAllAdminResult = _adminService.GetAllAdmins();
            return getAllAdminResult.Match(admin => Ok(MapAdminResponse(admin)), errors => Problem(errors));

        }
        [HttpPut("upsertAdmin/{id}")]
        public IActionResult UpsertAdmin(int id, UpsertAdminRequest request)
        {
            ErrorOr<AdminS> requestToUpsertAdmin = AdminS.From(id, request);
            if (requestToUpsertAdmin.IsError)
            {
                return Problem(requestToUpsertAdmin.Errors);
            }
            var admin = requestToUpsertAdmin.Value;
            ErrorOr<Updated> upsertAdminRequest = _adminService.UpsertAdmin(admin);
            return upsertAdminRequest.Match(admin => NoContent(), errors => Problem(errors));
        
        }
        private static List<TeacherResponse> MapToTeacherResponse(DataTable Teacher)
        {
            var teachers = Teacher;
            var teacherResponses = new List<TeacherResponse>();
            foreach (DataRow row in teachers.Rows)
            {
                var response = new TeacherResponse(
                    int.Parse(row["id"].ToString()),
                    row["forename"].ToString(),
                    row["surname"].ToString(),
                    int.Parse(row["idNumber"].ToString()),
                    row["phonenumber"].ToString(),
                    row["tscnumber"].ToString(),
                    row["department"].ToString(),
                    row["employer"].ToString(),
                    row["EmployementType"].ToString()
                );

                teacherResponses.Add(response);
            }
            return teacherResponses;
        } private static List<AdminResponse> MapAdminResponse(DataTable Admin)
        {
            var admins = Admin;
            var adminResponses = new List<AdminResponse>();
            foreach (DataRow row in admins.Rows)
            {
                var response = new AdminResponse(
                    int.Parse(row["id"].ToString()),
                    row["AdminName"].ToString(),
                    int.Parse(row["AdminID"].ToString()),
                    row["Email"].ToString(),
                    row["Password"].ToString()
                );

                adminResponses.Add(response);
            }
            return adminResponses;
        }
    }
}
