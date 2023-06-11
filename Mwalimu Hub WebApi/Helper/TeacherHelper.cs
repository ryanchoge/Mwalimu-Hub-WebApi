using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_API.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using XSystem.Security.Cryptography;

namespace Mwalimu_Hub_WebApi.Helper
{
    public class TeacherHelper
    {
        public static bool CreateTeacher(Teacher teacher)
        {
            string password = teacher.Password;
            byte[] passwordHash = Encoding.UTF8.GetBytes(password);
            SHA512Managed sha = new SHA512Managed();
            byte[] hashedPassword = sha.ComputeHash(passwordHash);
            DatabaseHelper databaseHelper = new DatabaseHelper();
            SqlParameter[] parameter = {new SqlParameter("forename",teacher.Forename),new SqlParameter("id", -1),
                                            new SqlParameter("surname", teacher.Surname),
                                            new SqlParameter( "tscnumber", teacher.TscNumber),new SqlParameter("idnumber", teacher.IdNumber),
                                            new SqlParameter( "phonenumber", teacher.PhoneNumber),new SqlParameter( "employer", teacher.Employer),
                                            new SqlParameter("employmenttype", teacher.EmployerType),new SqlParameter("department", teacher.Department),
                                            new SqlParameter( "Password", hashedPassword), };
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPRegisterTeacher", parameter);
            if (rowsAffected == 1)
            {
                bool teacherCreated = true;
                return teacherCreated;
            }
            return false;
           
        }
        public static void EditTeacher(Teacher teacher)
        {

        }
        public static void DeleteTeacher(int id)
        {

        }
    }
}
