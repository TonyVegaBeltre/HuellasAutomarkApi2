using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Domain.Entities
{
    [Table("Cliente")]
    public class Client
    {
       [Key]
        [Column("Id")]
        public int Id {get; set; }
        [Column("IdGenero")]
        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public virtual Gender Gender { get; set; } = null!;
        [Column("IdCiudad")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = null!;

        [Column("Nombre"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Column("Apellido"), MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Column("Correo"), MaxLength(150)]
        public string? Email { get; set; } = string.Empty;
        [Column("Telefono"), MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Column("FechaNacimiento")]
        public DateTime? BirthDate { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
