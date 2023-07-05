using ErrorOr;
using Mwalimu_Hub_WebApi.Models;
using Mwalimu_Hub_WebApi.ServiceErrors;
using MwalimuHub.Contracts.Admin;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Mwalimu_Hub_API.Models
{
    public class AdminS
    {
        public int Id { get; }
        public int AdminId { get; }
        public string AdminName { get; }
        public string AdminEmail { get; }
        public string Password { get; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        private AdminS(int id, int adminId, string adminName, string adminEmail, string password, byte[] passwordHash, byte[] passwordSalt )
        {
            
            Id = id;
            AdminId = adminId;
            AdminName = adminName;
            AdminEmail = adminEmail;
            Password = password;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
       
        public ErrorOr<AdminS> Create (int id, int adminId, string adminName, string adminEmail, string password)
        {
            List<Error> errors = new();
            if(id.ToString() == string.Empty || adminId.ToString() == string.Empty || adminEmail == string.Empty || password ==string.Empty)
            {
                return AdminErrors.Admin.InValidFields;
            }
            if(!Regex.Match(adminId.ToString(), "^[0-9]*$").Success )
            {
                 errors.Add(AdminErrors.Admin.InvlidId);
            }
            if(!Regex.Match(adminName.ToString(), "^[a-z]*$").Success )
            {
                 errors.Add(AdminErrors.Admin.InvlidName);
            }
            if(!Regex.Match(adminEmail.ToString(), "^[a-z]*$").Success)
            {
                errors.Add(AdminErrors.Admin.InvalidEmail);
            }
            if (errors.Count > 0)
            {
                return errors;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
           
            return new AdminS(id, adminId, adminName, adminEmail, password, passwordHash, passwordSalt);
        }
        public static ErrorOr<AdminS> Create(int adminId, string adminName, string adminEmail, string password, int? id = null)
        {
            List<Error> errors = new();
            if ( adminId.ToString() == string.Empty || adminName == string.Empty || adminEmail == string.Empty || password == string.Empty)
            {
                return AdminErrors.Admin.InValidFields;
            }
            if (!Regex.Match(adminId.ToString(), "^[0-9]*$").Success)
            {
                errors.Add(AdminErrors.Admin.InvlidId);
            }
            //if (!Regex.Match(adminName.ToString(), "^[a-z]*$").Success)
            //{
            //    errors.Add(AdminErrors.Admin.InvlidName);
            //}
            if (!Regex.Match(adminEmail.ToString(), "^[a-zA-Z@.]*$").Success)
            {
                errors.Add(AdminErrors.Admin.InvalidEmail);
            }
            if (errors.Count > 0)
            {
                return errors;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            return new AdminS(id ?? -1, adminId, adminName, adminEmail, password, passwordHash, passwordSalt);
        }
        public static ErrorOr<AdminS> From( CreateAdminRequest request)
        {
            return Create(request.adminId, request.adminName, request.adminEmail, request.password);
        } 
        public static ErrorOr<AdminS> From(int id, UpsertAdminRequest request)
        {
            return Create(request.adminId, request.adminName, request.adminEmail, request.password, id);
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            using (hmac)
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
