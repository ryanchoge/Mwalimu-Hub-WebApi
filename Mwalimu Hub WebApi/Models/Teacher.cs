namespace Mwalimu_Hub_API.Models
{
    public class Teacher
    {
        public string Forename { get; set; }
        public string Surname { get; set; }   
        public string TscNumber { get; set; } = string.Empty;
        public int IdNumber { get; set; }
        public string Employer { get; set; } = string.Empty;
        public string EmployerType { get; set; } = string.Empty;    
        public string Password { get;set; } = string.Empty;
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
     
    }
}
