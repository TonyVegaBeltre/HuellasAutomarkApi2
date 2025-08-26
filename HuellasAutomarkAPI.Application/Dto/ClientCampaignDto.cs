using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Dto
{
    public class ClientCampaignDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;

        public int CampaignId { get; set; } 
        public string CampaignName { get; set; } = string.Empty;
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public DateTime? SendDate { get; set; }
        public string Observations { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
