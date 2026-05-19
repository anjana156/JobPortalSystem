using Domain.Application.Features.Login.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Login.Repositories
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        protected readonly JobPortalDbContext _context;
        public LoginRequestRepository(JobPortalDbContext dbContext)
        {
            _context = dbContext;
        }

        public Domain.Models.AuthUser GetUserByEmail(string email)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email);
            return user;
        }


        public Domain.Models.AuthUser GetUserByEmailpassword(string email, string password)
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email && e.Password == password);
            return user;
        }
    }
}
