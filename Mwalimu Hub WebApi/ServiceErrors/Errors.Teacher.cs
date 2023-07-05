using ErrorOr;

namespace Mwalimu_Hub_WebApi.ServiceErrors
{
    public static class Errors
    {                                 
        public static class TeacherS
        {
            public static Error NotFound => Error.NotFound(code: "Teacher.NotFound", description: "Teacher not found");
            public static Error InValidId => Error.Validation(code :"Teacher.InvalidIdNumber",
                description : "Teacher Id Number is invalid");
           
           
            public static Error InValidFields => Error.Validation(code : "Teacher.InValidFields",
                description : "All fields must be field");
            
            public static Error InValidForename => Error.Validation(code : "Teacher.InValidForeName", description : "Teacher forename is invalid");  
            public static Error InValidSurName => Error.Validation(code : "Teacher.InValidSurName", description : "Teacher surname is invalid");
            public static Error InValidPhoneNumber => Error.Validation(code : "Teacher.InValidPhoneNumber", description : "Phone number is invalid");public static Error InValidForeName => Error.Validation(code : "Teacher.InValidForeName", description : "Teacher forename is invalid");  
            public static Error InValidTscNumber => Error.Validation(code : "Teacher.InValidTscNumber", description : "Tsc Number is invalid");
        }
    }
}
