using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwalimuHub.Contracts.Authentication
{
    public record LoginResponse(string name, string idnumber, string email, string token);
}
