<<<<<<< HEAD
﻿using System;
=======
﻿using Domain.Application.Features.Login.DTO;
using Domain.Service.Login.DTOs;
using System;
>>>>>>> origin/sofnanash
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Domain.Service.Login.DTOs;
=======
>>>>>>> origin/sofnanash

namespace Domain.Service.Login.Interfaces
{
    public interface ILoginRequestService
    {
<<<<<<< HEAD

        JobSeekerLoginDto login(string email, string password);

        AdminLoginDTO Adminlogin(string email, string password);
=======
        LoginResponseDto Login(LoginRequestDto request);

>>>>>>> origin/sofnanash
    }
}
