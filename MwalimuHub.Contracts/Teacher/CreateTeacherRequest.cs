using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MwalimuHub.Contracts.Teacher
{
    public record CreateTeacherRequest(string forename, string surname,int idnumber,string phonenumber,
        string tscnumber, string department, string employer, string employmenttype,string password);
}
