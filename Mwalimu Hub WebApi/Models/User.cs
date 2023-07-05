namespace Mwalimu_Hub_WebApi.Models
{
    public class User
    {
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
