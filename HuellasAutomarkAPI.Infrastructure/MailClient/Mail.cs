using HuellasAutomarkAPI.Application.Dto;
using HuellasAutomarkAPI.Application.Interfaces.Mail;
using HuellasAutomarkAPI.Domain.Entities;
using HuellasAutomarkAPI.Infrastructure.MailClient;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace HuellasAutomarkAPI.Infrastructure.Mail
{

    public class MailService : IMail
    {
        private readonly SmtpSettings _smtpSettings;
        public MailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(MailMessageDto message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(message.ToEmail));
            email.Subject = message.Subject;

            //var templatePath = Path.Combine("C:\\Users\\antho\\source\\repos\\HuellasAutomarkApi2\\HuellasAutomarkAPI.Infrastructure\\", "MailClient", "MailTemplate", "AddClientCampaign.html");
            var templatePath = message.HtmlPath;

            var htmlTemplate = await File.ReadAllTextAsync(templatePath);

            string body = htmlTemplate
            .Replace("{{ClientName}}", $"{message.ClientName}")
            .Replace("{{CampaignName}}", message.CampaignName)
            .Replace("{{SendDate}}", message.SendDate.ToString("dd/MM/yyyy"))
            .Replace("{{Observations}}", message.Observations);
            var builder = new BodyBuilder
            {
                HtmlBody = body


            };
            var logoPath = builder.LinkedResources.Add(message.LogoPath);
            logoPath.ContentId = ("companylogo");

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }

    
}

