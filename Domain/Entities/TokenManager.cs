using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace taanbus.Domain.Entities
{
    public class TokenManager
    {
        private static string Secret = "4c2adnvdff2610443a5477834ce698b5ee643b84274e751612940d641401fbc7";
        //Metodo para generar el token Utomaticamente
        public static string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim(ClaimTypes.Name, username)
                }),
                //Configurar el tiempo de vencimiento del Token.
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler hendler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = hendler.CreateJwtSecurityToken(descriptor);
            return hendler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)handler.ReadJwtToken(token);
                if (jwtToken == null) return null;

                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    //Configurar Validaciones y Requerimientos
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static string ValidateToken (string token)
        {
            string username = null;

            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null) return null;

            ClaimsIdentity identity = null;

            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch(NullReferenceException)
            {
                return null;
            }
            Claim claim = identity.FindFirst(ClaimTypes.Name);
            username = claim.Value;
            return username;
        }
    }
}