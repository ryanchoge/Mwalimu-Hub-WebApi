using Mwalimu_Hub_API.Models;

namespace Mwalimu_Hub_WebApi.Services.Aurhenticaton
{
    public interface IAuthenticationService
    {
        public AuthenticationResult Login(AdminS admin);

    }
}
