<<<<<<< HEAD
﻿using System;
=======
﻿using Domain.Application.Features.Login.Interfaces;
using Domain.Models;
using System;
>>>>>>> origin/nasilanasry
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Domain.Models;
using Domain.Service.Login.Interfaces;
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> origin/nasilanasry

namespace Domain.Application.Features.Login.Repositories
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        protected readonly JobPortalDbContext _context;
        public LoginRequestRepository(JobPortalDbContext dbContext)
        {
            _context = dbContext;
        }

<<<<<<< HEAD
        public AuthUser GetUserByEmail(string email)
=======
        public Domain.Models.AuthUser GetUserByEmail(string email)
>>>>>>> origin/nasilanasry
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email);
            return user;
        }


<<<<<<< HEAD
        public AuthUser GetUserByEmailpassword(string email, string password)
=======
        public Domain.Models.AuthUser GetUserByEmailpassword(string email, string password)
>>>>>>> origin/nasilanasry
        {
            var user = _context.AuthUsers.FirstOrDefault(e => e.Email == email && e.Password == password);
            return user;
        }
    }
<<<<<<< HEAD
    }
=======
}
>>>>>>> origin/nasilanasry
