using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.ExternalServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/nasilanasry
