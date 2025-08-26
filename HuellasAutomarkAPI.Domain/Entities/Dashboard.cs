using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities
{
    public class Dashboard
    {

        public int TotalClients { get; set; }

        public int TotalCampaigns { get; set; }

        public Dictionary<string, int> ClientsByCity { get; set; } = [];

        public Dictionary<string, int> ClientsByGender { get; set; } = [];

        public Dictionary<string, int> TotalClientsByCampaign { get; set; }= [];

    }
    public class ClientsByCity
    {
        public string ClientName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;

        public string TotalClientsByCity { get; set; } = string.Empty;
    }
    public class ClientsByGender
    {
        public string ClientName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
    public class TotalClientsByCampaign
    {
        public string ClientName { get; set; } = string.Empty;
        public string CampaignTitle { get; set; } = string.Empty;
    }

}
