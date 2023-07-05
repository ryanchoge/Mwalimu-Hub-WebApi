using ErrorOr;
using Mwalimu_Hub_API.Models;
//using MwalimuHub.Contracts.Admin;
//using Mwalimu_Hub_WebApi.Services.Admin;
using System.Data;

namespace Mwalimu_Hub_WebApi.Services.AdminService
{
    public interface IAdminService
    {
        ErrorOr<Created> CreateAdmin(AdminS admin);
        ErrorOr<Created> CreateTeacher(Teacher teacher);
        ErrorOr<DataTable> GetAllAdmins();
        ErrorOr<DataTable> GetAllTeachers();
        ErrorOr<DataTable> GetTeacher(int id);
        ErrorOr<Updated> UpsertTeacher(Teacher teacher);
        ErrorOr<Deleted> DeleteTeacher(int id);
        ErrorOr<Updated> UpsertAdmin(AdminS admin);
        
    }
}
