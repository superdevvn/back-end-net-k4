using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Utilities
{
    public class JWT
    {
        public static string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        public static int expireMinutes = 1200;
        private static TokenValidationParameters tokenValidationParameters
        {
            get
            {
                var symmetricKey = Convert.FromBase64String(Secret);
                return new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Secret))
                };
            }
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
                    return null;


                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                return principal;
            }

            catch (Exception)
            {
                //should write log
                return null;
            }
        }

        private static ClaimsIdentity ValidateToken(string token)
        {
            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null) throw new InvalidTokenException();

            if (!identity.IsAuthenticated) throw new InvalidTokenException();

            return identity;
        }

        public static string GenerateToken(CustomIdentity customIdentity)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(customIdentity),
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static CustomIdentity AuthenticateJwtToken(string token)
        {
            var identity = ValidateToken(token);
            return new CustomIdentity(identity);
        }
    }
}
