using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Interfaces.Mail
{
    public interface IMail
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);

    }
}
