using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Login.Interfaces
{
    public interface ILoginRequestRepository
    {

        Domain.Models.AuthUser GetUserByEmail(string email);
        Domain.Models.AuthUser GetUserByEmailpassword(string email, string password);
    }
}
