﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.Dto
{
    public class CreateClientCampaignDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StateId { get; set; }
        public int CampaignId { get; set; }
        public DateTime? SendDate { get; set; }
        public string Observations { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
