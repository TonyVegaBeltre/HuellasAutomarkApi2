using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Dto
{
    public class MailMessageDto
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string CampaignName { get; set; } = string.Empty;
        public DateTime SendDate { get; set; } 
        public string Observations { get; set; } = string.Empty;
        public string HtmlPath { get; set; } = "C:\\Users\\antho\\source\\repos\\HuellasAutomarkApi2\\HuellasAutomarkAPI.Infrastructure\\MailClient\\MailTemplate\\AddClientCampaign.html";
        public string LogoPath { get; set; } = "C:\\Users\\antho\\source\\repos\\HuellasAutomarkApi2\\HuellasAutomarkAPI\\wwwroot\\images\\HuellasLogo.jpeg";

    }
}
