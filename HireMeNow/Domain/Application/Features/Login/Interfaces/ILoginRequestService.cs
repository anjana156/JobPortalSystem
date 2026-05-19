<<<<<<< HEAD

﻿using Domain.Application.Features.Login.DTO;
using Domain.Service.Login.DTOs;
=======
﻿using Domain.Application.Features.Login.DTO;
>>>>>>> origin/nasilanasry
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD

namespace Domain.Service.Login.Interfaces
=======
namespace Domain.Application.Features.Login.Interfaces
>>>>>>> origin/nasilanasry
{
    public interface ILoginRequestService
    {

<<<<<<< HEAD
        LoginResponseDto Login(LoginRequestDto request);


=======
        JobSeekerLoginDto login(string email, string password);

        //AdminLoginDTO Adminlogin(string email, string password);
>>>>>>> origin/nasilanasry
    }
}
