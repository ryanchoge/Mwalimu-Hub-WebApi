using Mwalimu_Hub_API.Models;
using Mwalimu_Hub_API;
namespace Mwalimu_Hub_WebApi.Services.Aurhenticaton
{
    public class AuthenticationService : IAuthenticationService
    {
         AuthenticationResult Login(AdminS admin)
        {
            return new AuthenticationResult(admin.AdminName, admin.AdminEmail, admin.Password);
        }

        AuthenticationResult IAuthenticationService.Login(AdminS admin)
        {
            throw new NotImplementedException();
        }
    }
}
