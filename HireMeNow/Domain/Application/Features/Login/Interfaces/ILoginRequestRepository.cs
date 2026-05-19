<<<<<<< HEAD
﻿using System;
=======
﻿using Domain.Models;
using System;
>>>>>>> origin/nasilanasry
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Domain.Models;

namespace Domain.Service.Login.Interfaces
=======

namespace Domain.Application.Features.Login.Interfaces
>>>>>>> origin/nasilanasry
{
    public interface ILoginRequestRepository
    {

<<<<<<< HEAD
        AuthUser GetUserByEmail(string email);
		AuthUser GetUserByEmailpassword(string email,string password);
	}
=======
        Domain.Models.AuthUser GetUserByEmail(string email);
        Domain.Models.AuthUser GetUserByEmailpassword(string email, string password);
    }
>>>>>>> origin/nasilanasry
}
