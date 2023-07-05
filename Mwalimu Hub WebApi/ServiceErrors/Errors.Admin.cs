using ErrorOr;

namespace Mwalimu_Hub_WebApi.ServiceErrors
{
    public static class AdminErrors
    {
        public static class Admin
        {
            public static Error InValidFields => Error.Validation(code: "Admin.InValidFields",
                description: "All fields must be field");

            public static Error NotFound => Error.NotFound(code: "Admin.NotFound", description: "Admin not found");
            public static Error InvlidId => Error.Validation(code: "Admin.InvalidId", description: "Admin Id Number is invalid"); 
            public static Error InvlidName => Error.Validation(code: "Admin.InvalidName", description: "Admin name is invalid");
            public static Error InvalidEmail => Error.NotFound(code: "Admin.InvalidEmail", description: "Admin email is invalid");


        }
    }
}
