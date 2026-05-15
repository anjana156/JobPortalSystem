using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;

namespace Domain.Infrastructure.ExternalServices
{
    public interface IMailServices
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
