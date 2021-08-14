using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        [MaxLength(10)]
        [Column("USUARIO_ATUALIZACAO")]
        public string Usuario_Atualizacao { get; set; }
        [Required]
        [Column("DATA_ATUALIZACAO")]
        public DateTime Data_Atualizacao { get; set; }
    }
}
