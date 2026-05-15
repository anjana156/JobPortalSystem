using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authentication.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<Domain.Models.AuthUser> AddAuthUser(Domain.Models.AuthUser authUser);

        Task<Domain.Models.AuthUser> AddAuthUserJP(Domain.Models.AuthUser authUser);
        string? CreateToken(Domain.Models.AuthUser user);
        CompanyUser GetUser(Guid userid);
        Task AddUserConnectionIdAsync(string email, string ConnectionId);
        Domain.Models.AuthUser GetUserByConnectionId(string connectionId);
        Task<Domain.Models.AuthUser> GetAuthUserByUserEmail(string user);
        void DisconnectUserByConnectionId(string connectionId);
        Task<Domain.Models.AuthUser> GetAuthUserByUserId(Guid value);
    }
}
