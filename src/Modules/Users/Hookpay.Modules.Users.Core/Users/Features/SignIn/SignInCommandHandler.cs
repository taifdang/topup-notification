﻿using Hookpay.Modules.Users.Core.Data;
using Hookpay.Shared.Caching;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hookpay.Modules.Users.Core.Users.Features.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
{
    private readonly UserDbContext _context;
    private readonly IRequestCache _cache;
    public SignInCommandHandler(UserDbContext context,IRequestCache cache) {  _context = context;_cache = cache; }
    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        //email:index non-cluster
        var user =  await _context.users.SingleOrDefaultAsync(x => x.user_email == request.email);
        if (user is null) return string.Empty;
        if (!user.user_password.Equals(request.password)) return string.Empty;
        if (user is null) return string.Empty;
        var result = GenerateJwtToken(user.user_id,user.user_email,user.user_name);
        return result;
    }
    public string GenerateJwtToken(int userId,string email,string username)
    {
        var claims = new[]
        {
            new Claim("uid",userId.ToString()),        
            new Claim(JwtRegisteredClaimNames.Name,username),
            new Claim(JwtRegisteredClaimNames.Email,email),
            new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this-is-key-jwt-security"));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "https://hookpay.com",
            audience: "https://hookpay.com",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(10)
            );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtToken;
        
    }
}
