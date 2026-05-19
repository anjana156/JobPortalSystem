using Domain.Application.Features.Login.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Features.Login.Interfaces
{
    public interface ILoginRequestService
    {

        JobSeekerLoginDto login(string email, string password);

        //AdminLoginDTO Adminlogin(string email, string password);
    }
}
