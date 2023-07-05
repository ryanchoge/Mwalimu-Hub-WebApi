using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwalimuHub.Contracts.Admin
{
    public record AdminResponse(int id, string adminName, int adminId, string email, string password);
}
