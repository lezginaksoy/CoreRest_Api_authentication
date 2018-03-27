using System;
using System.IdentityModel.Tokens.Jwt;

namespace Identity_WebApi_Jwt.Middleware
{
    public sealed class JsonWebToken
    {
        private JwtSecurityToken token;

        internal JsonWebToken(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;
        public string Value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}
