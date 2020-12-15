using Microsoft.IdentityModel.Tokens;
using MyBlogApi.Models;
using MyBlogApi.Services.Interfaces;
using MyBlogApi.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogApi.Services.Logic
{
    public class JWTService : IJWTService
    {

        public IImmutableDictionary<string, RefreshToken> tokenDictionarty => userRefreshToken.ToImmutableDictionary();
        private readonly ConcurrentDictionary<string, RefreshToken> userRefreshToken;
        private readonly JWTTokenConfig jwttokenConfig;
        readonly byte[] secret;

        public JWTService(JWTTokenConfig jwttokenConfig)
        {
            this.jwttokenConfig = jwttokenConfig;
            userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
            secret = Encoding.ASCII.GetBytes(jwttokenConfig.Secret);
        }

        public JwtAuthResult GenerateToken(string userName, DateTime now)
        {
            var jwtToken = new JwtSecurityToken(
                jwttokenConfig.Issuer,
                string.Empty,
                null,
                expires: now.AddMinutes(jwttokenConfig.TokenExperation),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refreshToken = new RefreshToken()
            {
                Username = userName,
                Expiration = now.AddMinutes(jwttokenConfig.TokenExperation),
                TokenString = GenerateRefreshTokenString()
            };

            userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);

            JwtAuthResult token = new JwtAuthResult()
            {
                TokenString = accessToken,
                RefreshToken = refreshToken
            };

            return token;

        }

        private string GenerateRefreshTokenString()
        {
            var number = new Byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
