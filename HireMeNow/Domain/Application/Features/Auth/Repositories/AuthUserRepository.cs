using AutoMapper;
using Domain.Application.Features.AuthUser.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.AuthUser.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        protected readonly JobPortalDbContext _context;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public AuthUserRepository(JobPortalDbContext dbContext, IMapper _mapper, IConfiguration configuration)
        {
            _context = dbContext;
            mapper = _mapper;
            _configuration = configuration;
        }

        public async Task<Domain.Models.AuthUser> AddAuthUser(Domain.Models.AuthUser authUser)
        {
            authUser.Role = Enums.Role.JOB_SEEKER;
            await _context.AuthUsers.AddAsync(authUser);
            JobSeeker jobSeeker = mapper.Map<JobSeeker>(authUser);
            await _context.JobSeekers.AddAsync(jobSeeker);
            JobSeekerProfile jp = new();
            jp.JobSeekerId = jobSeeker.Id;
            await _context.JobSeekerProfiles.AddAsync(jp);
            await _context.SaveChangesAsync();
            return authUser;
        }

        public async Task<Domain.Models.AuthUser> AddAuthUserJP(Domain.Models.AuthUser authUser)
        {
            authUser.Role = Enums.Role.JOB_PROVIDER;
            await _context.AuthUsers.AddAsync(authUser);
            Models.CompanyUser jobProvider = mapper.Map<Models.CompanyUser>(authUser);
            await _context.CompanyUsers.AddAsync(jobProvider);
            await _context.SaveChangesAsync();
            return authUser;
        }

        public string? CreateToken(Domain.Models.AuthUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");
            }
            string tokenSecret = _configuration.GetSection("AuthSettings:Token").Value;
            if (string.IsNullOrEmpty(tokenSecret))
            {
                throw new InvalidOperationException("Token secret is missing or empty in configuration.");
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public Domain.Models.AuthUser GetUserByConnectionId(string connectionId)
        {
            return _context.AuthUsers.FirstOrDefault(u => u.ConnectionId == connectionId);
        }

        public async Task<Domain.Models.AuthUser> GetAuthUserByUserEmail(string email)
        {
            return await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Domain.Models.AuthUser> GetAuthUserByUserId(Guid userId)
        {
            return await _context.AuthUsers.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public CompanyUser GetUser(Guid userid)
        {
            return _context.CompanyUsers.Where(e => e.Id == userid).FirstOrDefault();
        }

        public async Task AddUserConnectionIdAsync(string email, string ConnectionId)
        {
            var userToUpdate = _context.AuthUsers.Where(e => e.Email == email).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.ConnectionId = ConnectionId;
                await _context.SaveChangesAsync();
            }
        }

        public void DisconnectUserByConnectionId(string connectionId)
        {
            var user = _context.AuthUsers.FirstOrDefault(u => u.ConnectionId == connectionId);
            if (user != null)
            {
                user.ConnectionId = null;
                _context.SaveChanges();
            }
        }
    }
}