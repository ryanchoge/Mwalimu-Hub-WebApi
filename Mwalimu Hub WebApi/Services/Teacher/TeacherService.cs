using ErrorOr;
using Mwalimu_Hub_API.Database;
using Mwalimu_Hub_WebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace Mwalimu_Hub_WebApi.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        DatabaseHelper databaseHelper = new();

        public void DeleteTeacher(int id)
        {
            SqlParameter[] parameter = { new SqlParameter("idnumber", id) };
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPDeleteTeacher", parameter);
        }

        public void GetAttendance(int id)
        {
            SqlParameter[] parameter = {new SqlParameter("ScheduleId", id) };
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPSaveAttendance", parameter);
            if (rowsAffected == 1)
            {
                //return Attendance;
                //return Ok("Attendance Saved Successfully");
            }
            else
            {
                //return BadRequest("Failed");
            }
        }

        public ErrorOr<DataTable> GetTeacher(int id)
        {
            
            SqlParameter[] sqlParameters = { new SqlParameter("@idnumber", id) };
            DataTable datatable = databaseHelper.ExecuteStoredProcedure("SPSingleteacher", sqlParameters);

            if (datatable.Rows.Count == 1)
            {
                //foreach(DataRow row in datatable.Rows)
                //{
                //    string ids = row["idNumber"].ToString();
                //    _teacher.Add(1, row);
                //}
                return datatable;

            }
            return datatable;
        }

        public void SaveAttendance(Attendance attendance)
        {
            

            SqlParameter[] parameter = {new SqlParameter("ClassCode",attendance.ScheduleId),new SqlParameter("id", attendance.Id ),
                                            new SqlParameter("Time", attendance.Time), new SqlParameter("Day", attendance.Day),
                                            new SqlParameter( "StudentNo", attendance.StudentNo),new SqlParameter( "Status", attendance.ScheduleId) };
            int rowsAffected = databaseHelper.ExecuteNonQueryStoredProcedure("SPSaveAttendance", parameter);
            if (rowsAffected == 1)
            {
                //return Ok("Attendance Saved Successfully");
            }
            else
            {
               //return BadRequest("Failed");
            }
        }
    }
}
