using System.IdentityModel.Tokens.Jwt;

namespace CharityConnect.MVC.Helpers
{
    public static class JwtHelper
    {
        public static string? GetUserRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            return jwt.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
        }
    }
}
