using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using XSystem.Security.Cryptography;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
 
        [HttpPost("admin/login")]
        public IActionResult AdminLogin([FromBody] Admin admin)
        {
            try
            {
                string adminid = admin.AdminId.ToString();
                string password = admin.Password;
                byte[] passwordHash = Encoding.UTF8.GetBytes(password);
                SHA512Managed sha = new SHA512Managed();
                byte[] hashedPassword = sha.ComputeHash(passwordHash);
                if (!Regex.Match(adminid, "^[0-9]*$").Success)
                {
                    return BadRequest("Invalid User ID");
                }
                else
                {
                    SqlParameter[] parameters = { new SqlParameter("@username",adminid) ,new SqlParameter("@password", hashedPassword) };
                    DataTable dataTable = databaseHelper.ExecuteStoredProcedure("SPAuthenticate", parameters);
                    if (dataTable.Rows.Count > 0)
                    {
                        return Ok("Success");
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }

                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        } 
        [HttpPost("teacher/login")]
        public IActionResult TeacherLogin([FromBody] Teacher teacher)
        {


            try
            {
                string adminid = teacher.IdNumber.ToString();
                string password = teacher.Password;
                byte[] passwordHash = Encoding.UTF8.GetBytes(password);
                SHA512Managed sha = new SHA512Managed();
                byte[] hashedPassword = sha.ComputeHash(passwordHash);
                if (!Regex.Match(adminid, "^[0-9]*$").Success)
                {
                    return BadRequest("Invalid User ID");
                }
                else
                {
                    SqlParameter[] parameters = { new SqlParameter("@username",teacher.IdNumber),new SqlParameter("@password", teacher.Password) };
                    DataTable dataTable = databaseHelper.ExecuteStoredProcedure("SPAuthenticateTeacher", parameters);
                    if (dataTable.Rows.Count > 0)
                    {
                        return Ok("Success");
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

