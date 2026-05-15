using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Login.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Application.Features.Login.Repositories
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        protected readonly JobPortalDbContext _context;
        public LoginRequestRepository(JobPortalDbContext dbContext)
        {
            _context = dbContext;
        }

        public AuthUser GetUserByEmail(string email)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email);
            return user;
        }


        public AuthUser GetUserByEmailpassword(string email, string password)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email && e.Password == password);
            return user;
        }
    }
    }
