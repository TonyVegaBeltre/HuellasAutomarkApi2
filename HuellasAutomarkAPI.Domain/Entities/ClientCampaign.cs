using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities
{
    [Table("ClienteCampaña")]
    public class ClientCampaign
    {
       [Key]
        [Column("Id")]
        public int Id {get; set; }

        [Column("IdCliente")]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; } = null!;

        [Column("IdEstado")]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;

        [Column("IdCampaña")]
        public int CampaignId { get; set; }
        [ForeignKey(nameof(CampaignId))]
        public virtual Campaign Campaign { get; set; } = null!;

        [Column("FechaEnvio")]
        public DateTime? SendDate { get; set; }

        [Column("Observaciones"), MaxLength(500)]
        public string Observations { get; set; } = string.Empty;

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
