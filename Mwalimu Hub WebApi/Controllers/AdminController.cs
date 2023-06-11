using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_WebApi.Helper;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
        // GET: api/<AdminController>
        //[HttpPost("createAdmin")]
        //public IActionResult CreateAdmin([FromBody] Admin admin)
        //{
        //    try
        //    {
        //        string password = admin.Password;
        //        string name = admin.AdminName;
        //        string email = admin.AdminEmail;
        //        string adminId = admin.AdminId.ToString();

        //        if (name == string.Empty || adminId == string.Empty || email == string.Empty || password == string.Empty)
        //        {
        //            TempData["Message"] = "All fields must be filled";
        //            return RedirectToAction("Index");

        //        }

        //        if (!Regex.Match(email, "^[a-zA-Z0-9@.]*$").Success)
        //        {
        //            TempData["Message"] = "Invalid Email";
        //            return RedirectToAction("Index");
        //        }
        //        if (!Regex.Match(name, "^[a-zA-Z ]*$").Success || name.Length > 100)
        //        {
        //            TempData["Message"] = "Invalid Name";
        //            return RedirectToAction("Index");
        //        }
        //        if (adminId == string.Empty || adminId.Length > 9 || adminId.Length < 6)
        //        {
        //            TempData["Message"] = "Invalid Id Number.";
        //            return RedirectToAction("Index");
        //        }
        //        //bool teacherCreated = TeacherHelper.CreateTeacher(teacher);

        //    }
        //[HttpPost("createTeacher")]
        //public IActionResult TeacherRegister([FromBody] Admin admin)
        //{
        //    if (admin.AdminId == 38030816 && admin.Password == "password")
        //    {
        //        return Ok("Success");
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid credentials");
        //[HttpPost("createTeacher")]
        //public IActionResult TeacherRegister([FromBody] Admin admin)
        //{
        //    if (admin.AdminId == 38030816 && admin.Password == "password")
        //    {
        //        return Ok("Success");
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid credentials");
        //    }
        //}
    }
}
