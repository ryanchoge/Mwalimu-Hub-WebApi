namespace Mwalimu_Hub_API.Models
{
    public class Admin
    {
        public int id { get; set; } 
        public int AdminId { get; set; }  
        public string AdminName { get; set; } = string.Empty;
        public string AdminEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
