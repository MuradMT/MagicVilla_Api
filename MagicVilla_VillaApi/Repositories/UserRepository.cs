﻿using AutoMapper;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Models.Dtos;
using MagicVilla_VillaApi.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private string secretKey;
        public UserRepository(ApplicationDbContext db,IMapper mapper,IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string username)
        {
           var user=_db.LocalUsers.FirstOrDefault(x=>x.UserName==username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _db.LocalUsers.FirstOrDefaultAsync
                 (x => x.UserName == loginRequestDto.Username &&
                 x.Password == loginRequestDto.Password);
            if(user == null)
            {
                return null;
            }
            var tokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role),
                }),
                Expires=DateTime.UtcNow.AddDays(1),
                SigningCredentials=new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
               
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginResponseDto = new LoginResponseDto()
            {
                Token =tokenHandler.WriteToken(token),
                User=user
            };
            return loginResponseDto;
        }

        public async Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
        {
           var user=_mapper.Map<LocalUser>(registrationRequestDto);
            await _db.LocalUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            user.Password = "";//for security
            return user;
        }
    }
}
