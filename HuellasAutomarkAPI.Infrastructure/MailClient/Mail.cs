using HuellasAutomarkAPI.Infrastructure.MailClient;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace HuellasAutomarkAPI.Infrastructure.Mail
{
    public interface IMail
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
    }


    public class MailService : IMail
    {
        private readonly SmtpSettings _smtpSettings;
        public MailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = isHtml ? body : null,
                TextBody = !isHtml ? body : null
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);


        }
    }
    
}

