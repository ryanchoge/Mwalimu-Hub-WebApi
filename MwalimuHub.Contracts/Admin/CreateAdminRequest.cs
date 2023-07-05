using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwalimuHub.Contracts.Admin
{
    public record CreateAdminRequest(int adminId, string adminName, string adminEmail, string password);
}
