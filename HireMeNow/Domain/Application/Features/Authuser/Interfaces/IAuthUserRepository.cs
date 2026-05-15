using Domain.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> origin/sofnanash

namespace Domain.Application.Features.Authuser.Interfaces
{
    public interface IAuthUserRepository
    {
<<<<<<< HEAD
        Task<AuthUser> AddAuthUser(AuthUser authUser);

        Task<AuthUser> AddAuthUserJP(AuthUser authUser);
        string? CreateToken(AuthUser user);
        CompanyUser GetUser(Guid userid);
        Task AddUserConnectionIdAsync(string email, string ConnectionId);
        AuthUser GetUserByConnectionId(string connectionId);
        Task<AuthUser> GetAuthUserByUserEmail(string user);
        void DisconnectUserByConnectionId(string connectionId);
        Task<AuthUser> GetAuthUserByUserId(Guid value);
        //Task<AuthUser> getUserByEmail(string? from);
=======
        Task<Models.AuthUser> AddAuthUser(Models.AuthUser authUser);

        Task<Models.AuthUser> AddAuthUserJP(Models.AuthUser authUser);
        string? CreateToken(Models.AuthUser user);
        Task<Models.AuthUser> GetAuthUserByUserEmail(string user);
        Task<Models.AuthUser> GetAuthUserByUserId(Guid value);


        CompanyUser GetUser(Guid userid);
        Task AddUserConnectionIdAsync(string email, string ConnectionId);
        Models.AuthUser GetUserByConnectionId(string connectionId);
        void DisconnectUserByConnectionId(string connectionId);
        
>>>>>>> origin/sofnanash
    }
}
