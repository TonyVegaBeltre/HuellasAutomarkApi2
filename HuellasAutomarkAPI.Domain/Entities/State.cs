using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities
{
    [Table("Estado")]
    public class State
    {
       [Key]
        [Column("Id")]
        public int Id {get; set; }

        [Column("Nombre"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
