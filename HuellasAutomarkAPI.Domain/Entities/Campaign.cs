using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities
{
    [Table("Campaña")]
    public class Campaign
    {
       [Key]
        [Column("Id")]
        public int Id {get; set; }
        [Column("IdCanal")]
        public int ChannelId { get; set; }

        [ForeignKey(nameof(ChannelId))]
        public virtual Channel Channel { get; set; } = null!;

        [Column("Titulo"),MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Column("Descripcion"), MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("FechaProgramada"),]
        public DateTime? ScheduledDate { get; set; }

        [Column("LinkPromocion"), MaxLength(255)]
        public string? PromotionLink { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
