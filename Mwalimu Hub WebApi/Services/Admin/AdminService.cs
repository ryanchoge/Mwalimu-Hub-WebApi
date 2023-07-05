using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_WebApi.ServiceErrors;
using Mwalimu_Hub_WebApi.Services.AdminService;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;
using XAct.Users;
using static Mwalimu_Hub_WebApi.ServiceErrors.AdminErrors;
using static Mwalimu_Hub_WebApi.ServiceErrors.Errors;

namespace Mwalimu_Hub_WebApi.Services.AdminService
{
    public class AdminService : IAdminService
    {
        DatabaseHelper databaseHelper = new();
        public static User user = new User();
        
        public ErrorOr<Created> CreateTeacher(Teacher teacher)
        {
            CreatePasswordHash(teacher.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            SqlParameter[] sqlParameters = { new SqlParameter("@id", teacher.Id), new SqlParameter("@forename", teacher.Forename),
                                            new SqlParameter("@surname", teacher.Surname), new SqlParameter("@idnumber", teacher.IdNumber), 
                                            new SqlParameter("@tscnumber", teacher.TscNumber), new SqlParameter("@department", teacher.Department),
                                            new SqlParameter("@employer", teacher.Employer), new SqlParameter("@employmenttype", teacher.EmployerType),
                                            new SqlParameter("@password", teacher.Password),new SqlParameter("@phonenumber", teacher.PhoneNumber)};
             databaseHelper.ExecuteNonQueryStoredProcedure("SPRegisterTeacher", sqlParameters);
            return Result.Created;
           
           
        }

        public ErrorOr<DataTable> GetTeacher(int id)
        {
            
            SqlParameter[] sqlParameters = { new SqlParameter("@idnumber", id)};
            DataTable datatable = databaseHelper.ExecuteStoredProcedure("SPSingleteacher", sqlParameters);

            if (datatable.Rows.Count >= 1)
            {
                return datatable;
            }
            return Errors.TeacherS.NotFound;
        }

        public ErrorOr<DataTable> GetAllTeachers()
        {
            DataTable datatable = databaseHelper.GetData("SPGetTeacherData");
            if (datatable.Rows.Count >= 1)
            {
                return datatable;
            }
            return Errors.TeacherS.NotFound;
        }



        public ErrorOr<Deleted> DeleteTeacher(int id)
        {
            SqlParameter[] parameter = { new SqlParameter("idnumber", id) };
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPDeleteTeacher", parameter);
            return Result.Deleted;
        }

        public ErrorOr<Updated> UpsertTeacher(Teacher teacher)
        {
                
                SqlParameter[] sqlParameters = { new SqlParameter("@id", teacher.Id), new SqlParameter("@forename", teacher.Forename),
                                            new SqlParameter("@surname", teacher.Surname), new SqlParameter("@idnumber", teacher.IdNumber),
                                            new SqlParameter("@tscnumber", teacher.TscNumber), new SqlParameter("@department", teacher.Department),
                                            new SqlParameter("@employer", teacher.Employer), new SqlParameter("@employmenttype", teacher.EmployerType),
                                            new SqlParameter("@password", teacher.Password),new SqlParameter("@phonenumber", teacher.PhoneNumber)};
                 int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPRegisterTeacher", sqlParameters);
            if(rowsAffected == 0)
            {
                return Error.Conflict(code: "User.Exist", description:"Failed to Update Teacher. Teacher with the same ID Number Already Exist");
            }
            return Result.Updated;
        }

        public ErrorOr<Created> CreateAdmin(AdminS admin)
        {
            SqlParameter[] sqlParameters = { new SqlParameter("@id", admin.Id), new SqlParameter("@userid", admin.AdminId),
                new SqlParameter("@name", admin.AdminName), new SqlParameter("@email", admin.AdminEmail),
                new SqlParameter("@password", admin.Password)};
           int rowsAffected =  databaseHelper.ExecuteNonQueryStoredProcedure("SpSaveAdmin", sqlParameters);
            if( rowsAffected < 0 )
            {
                return Error.Conflict(code: "Admin.Exist", description: "Failed to Add Admin. Admin with the same ID Number Already Exist");

            }
            return Result.Created;
        }

        public ErrorOr<DataTable> GetAllAdmins()
        {
            DataTable datatable = databaseHelper.GetData("SPGetAdmin");
            if(datatable.Rows.Count > 0)
            {
                return datatable;
            }
            return AdminErrors.Admin.NotFound;
        }

        public ErrorOr<Updated> UpsertAdmin(AdminS admin)
        {
            SqlParameter[] sqlParameters = { new SqlParameter("@id", admin.Id), new SqlParameter("@userid", admin.AdminId),
                new SqlParameter("@name", admin.AdminName), new SqlParameter("@email", admin.AdminEmail),
                new SqlParameter("@password", admin.Password)};
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SpSaveAdmin", sqlParameters);
            if (rowsAffected == 0)
            {
                return Error.Conflict(code: "Admin.Exist", description: "Failed to Add Admin. Admin with the same ID Number Already Exist");

            }
            return Result.Updated;
        }
         void CreatePasswordHash(string password, out byte[]passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            using (hmac)
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //void IAdminService.CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    throw new NotImplementedException();
        //}
    }

       
    
}
