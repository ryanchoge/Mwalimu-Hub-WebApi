using ErrorOr;
using Mwalimu_Hub_WebApi.ServiceErrors;
using MwalimuHub.Contracts.Teacher;
using System.Text.RegularExpressions;
using XAct;

namespace Mwalimu_Hub_API.Models
{
    public class Teacher
    {
        public const int minIdNumber = 6;
        public const int maxIdNumber = 8;
        public int Id { get; }
        public string Forename { get; }
        public string Surname { get; }
        public string TscNumber { get; }
        public int IdNumber { get; }
        public string Employer { get; }
        public string EmployerType { get; }
        public string Password { get; }
        public string Department { get; }
        public string PhoneNumber { get; }
        private Teacher(int id, string forename, string surname, int idNumber, string tscnumber, 
            string phoneNumber, string department, string employer, string employerType, string password)
        {
            //enforce variants
            Id = id;
            Forename = forename;
            Surname = surname;
            IdNumber = idNumber;
            TscNumber = tscnumber;
            PhoneNumber = phoneNumber;
            Department = department;
            Employer = employer;
            EmployerType = employerType;
            Password = password;
        }
        public static ErrorOr<Teacher> Create(string forename, string surname, int idNumber, string tscnumber, 
            string phoneNumber, string department, string employer,
            string employerType, string password, int? id = null)
        {
            List<Error> errors = new();
            if (forename == string.Empty || surname == string.Empty ||phoneNumber == string.Empty || employer == string.Empty
                || employerType == string.Empty || department == string.Empty ||password == string.Empty)
            {
                errors.Add(Errors.TeacherS.InValidFields);


            }
            if (!Regex.Match(forename, "^[a-zA-Z]*$").Success ||forename.Length > 100)
            {
                errors.Add(Errors.TeacherS.InValidForeName);

            }
            if (!Regex.Match(surname, "^[a-zA-Z]*$").Success || surname.Length > 50)
            {
                errors.Add(Errors.TeacherS.InValidSurName);

            }
            if (!Regex.Match(idNumber.ToString(), "^[0-9]*$").Success || idNumber.ToString().Length > 9 || idNumber.ToString().Length < 6)
            {
                errors.Add(Errors.TeacherS.InValidId);

            }

            if (!Regex.Match(phoneNumber, "^[0-9+]*$").Success || phoneNumber.Length > 20 || phoneNumber.Length < 10)
            {
                errors.Add(Errors.TeacherS.InValidPhoneNumber);

            }
         
            if (tscnumber == string.Empty)
            {
                   tscnumber = "0";
             }
            else if (tscnumber.Length < 7 || !Regex.Match(tscnumber, "^[0-9+]*$").Success)
            {
                errors.Add(Errors.TeacherS.InValidTscNumber);

            }

            if (errors.Count> 0)
            {
                return errors;
            }
            return new Teacher(id ?? -1, forename,surname, idNumber, tscnumber, phoneNumber, department, employer, employerType, password);
        }    
        public static ErrorOr<Teacher> Create(string forename, string surname, int idNumber, string tscnumber, 
            string phoneNumber, string department, string employer,
            string employerType, int? id = null)
        {
            List<Error> errors = new();
            if (forename == string.Empty || surname == string.Empty ||phoneNumber == string.Empty || employer == string.Empty
                || employerType == string.Empty || department == string.Empty )
            {
                errors.Add(Errors.TeacherS.InValidFields);


            }
            if (!Regex.Match(forename, "^[a-zA-Z]*$").Success ||forename.Length > 100)
            {
                errors.Add(Errors.TeacherS.InValidForeName);

            }
            if (!Regex.Match(surname, "^[a-zA-Z]*$").Success || surname.Length > 50)
            {
                errors.Add(Errors.TeacherS.InValidSurName);

            }
            if (!Regex.Match(idNumber.ToString(), "^[0-9]*$").Success || idNumber.ToString().Length > 9 || idNumber.ToString().Length < 6)
            {
                errors.Add(Errors.TeacherS.InValidId);

            }

            if (!Regex.Match(phoneNumber, "^[0-9+]*$").Success || phoneNumber.Length > 20 || phoneNumber.Length < 10)
            {
                errors.Add(Errors.TeacherS.InValidPhoneNumber);

            }
         
            if (tscnumber == string.Empty || tscnumber == "0")
            {
                   tscnumber = "0";
             }
            else if (tscnumber.Length < 5 || !Regex.Match(tscnumber, "^[0-9]*$").Success)
            {
                errors.Add(Errors.TeacherS.InValidTscNumber);

            }

            if (errors.Count> 0)
            {
                return errors;
            }
            return new Teacher(id ?? -1, forename,surname, idNumber, tscnumber, phoneNumber, department, employer, employerType,"");
        }
        public static ErrorOr<Teacher> From (int id, UpsertTeacherRequest request)
        {
            return Create(request.forename, request.surname,
                request.idnumber, request.tscnumber, request.phonenumber, request.department, request.employer, request.employmenttype,
                id);
        }
        public static ErrorOr<Teacher> From ( CreateTeacherRequest request)
        {
            return Create(request.forename, request.surname,
                request.idnumber, request.tscnumber, request.phonenumber, request.department, request.employer, request.employmenttype,
                request.password);
        }

       
    }
}
