using ErrorOr;
using Mwalimu_Hub_WebApi.Models;
using System.Data;

namespace Mwalimu_Hub_WebApi.Services.TeacherService
{
    public interface ITeacherService
    {
        void DeleteTeacher(int id);
        //void GetAttendance(int id);
        ErrorOr<DataTable> GetTeacher(int id);
        void SaveAttendance(Attendance attendance);
    }
}
