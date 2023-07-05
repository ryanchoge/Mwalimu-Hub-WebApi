 namespace Mwalimu_Hub_WebApi.Services.Authenticaton
{
    public interface IJwtTokenGenerator
    {
        public string GenerateJwtToken(string secretKey, string issuer, string audience, string userId,
            int expiryMinutes);


    }
}
