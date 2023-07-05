using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using XSystem.Security.Cryptography;
using System.Text.RegularExpressions;
using XAct;
using MwalimuHub.Contracts.Authentication;
using Microsoft.AspNetCore.Authentication;
using Mwalimu_Hub_WebApi.Services.Authenticaton;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mwalimu_Hub_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

       private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public AuthenticationController(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator; 
        }
        [HttpPost("admin")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            
            //_authenticationService.Login();
            
            return Ok(request);
        //    
           
        }


        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/<AuthenticationController>
        [HttpPost("teacher/login")]
        public IActionResult Post([FromBody]Teacher teachers)
        {
            DatabaseHelper databaseHelper = new();

            try
            {
                string teacherID = teachers.IdNumber.ToString();
                string password = teachers.Password;
                byte[] passwordHash = Encoding.UTF8.GetBytes(password);
                SHA512Managed sha = new SHA512Managed();
                byte[] hashedPassword = sha.ComputeHash(passwordHash);
                if (!Regex.Match(teacherID, "^[0-9]*$").Success)
                {
                    return BadRequest("Invalid User ID");
                }
                SqlParameter[] parameters = { new SqlParameter("@username", teachers.IdNumber)};

                DataTable dataTable = databaseHelper.ExecuteStoredProcedure("SPAuthenticateTeacher", parameters);
                foreach(DataRow row in dataTable.Rows)
                {
                    string dbPassword = row["Password"].ToString();
                    string hashpass = Encoding.UTF8.GetString( hashedPassword);
                    if (dbPassword == hashpass)
                    {
                        return Ok("Success");
                    }

                      
                   
                }
                return BadRequest("Invalid Credentials");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                retut
            }

        }


    }
}
