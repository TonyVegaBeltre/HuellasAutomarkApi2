using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Dto
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ScheduledDate { get; set; }
        public string? PromotionLink { get; set; }
        public bool IsActive { get; set; }

    }
}
