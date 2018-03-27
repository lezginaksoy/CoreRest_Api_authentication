using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity_WebApi_Jwt.Middleware
{
    public static class JsonWebTokenSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
