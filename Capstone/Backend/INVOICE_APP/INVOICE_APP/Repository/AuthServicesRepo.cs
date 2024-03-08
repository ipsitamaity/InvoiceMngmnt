using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using INVOICE_APP.Repository.Interfaces;
using INVOICE_APP.Models;

namespace INVOICE_APP.Repository
{
    public class AuthServicesRepo : IAuthServices
    {
        public readonly byte[] _secretKey;
        public readonly string _issuer;
        public readonly string _audience;
        public readonly int _expiryInMinutes;
        private object secretKey;
        private object issuer;
        private object audience;
        private object expiryInMinutes;

        //public AuthServicesRepo(IGetUserDtlsRepository getUserDtlsRepository, string secretKey, string issuer, string audience, int expiryInMinutes)
        //{
        //    _getUserDtlsRepository = getUserDtlsRepository;
        //    _secretKey = Encoding.UTF8.GetBytes("secretKey");
        //    _issuer = "issuer";
        //    _audience = "audience";
        //    _expiryInMinutes = 123456;
        //}

        public AuthServicesRepo(object secretKey, object issuer, object audience, object expiryInMinutes)
        {
            this.secretKey = secretKey;
            this.issuer = issuer;
            this.audience = audience;
            this.expiryInMinutes = expiryInMinutes;
        }

        public Users Authenticate(string username, string password)
        {
            GetUserDtlsRepository getUserDtlsRepository = new GetUserDtlsRepository("Data Source=APINP-ELPTIC7ZC\\SQLEXPRESS;Initial Catalog=INVOICE;User ID=tap2023;Password=tap2023;Encrypt=False");

            Users user = getUserDtlsRepository.GetUserDtls(username);

            if (user.Password != password)
            {
                user.Password = "";
                user.UserName = "";
            }

            return user;
        }

        public string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                // Additional claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here"));
            var time = DateTime.UtcNow.AddMinutes(15).AddSeconds(10);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = time,
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
