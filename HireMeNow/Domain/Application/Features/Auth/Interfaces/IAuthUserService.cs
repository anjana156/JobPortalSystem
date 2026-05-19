using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.AuthUser.Interfaces
{
    public interface IAuthUserService
    {

        string GetUserId();
        CompanyUser GetUser(Guid userid);

    }
}
