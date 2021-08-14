using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Domain.Entities
{
    public class TreinaPropostasEntity : BaseEntity
    {
        [Column("ID_TREINA_PROPOSTA")]
        public int Id_Treina_Proposta { get; set; }
        [Key]
        [Required]
        [Column("PROPOSTA")]
        public int Proposta { get; set; }
        [Required]
        [MaxLength(11)]
        [Column("CPF")]
        public string CPF { get; set; }
        [Required]
        [MaxLength(6)]
        [Column("CONVENIADA")]
        public string Conveniada { get; set; }
        [Required]
        [Column("VLR_SOLICITADO")]
        public float Vlr_Solicitado { get; set; }
        [Required]
        [Column("PRAZO")]
        public int Prazo { get; set; }
        [Required]
        [MaxLength(500)]
        [Column("OBSERVACAO")]
        public string Observacao { get; set; }
        [Required]
        [Column("VLR_FINANCIADO")]
        public float Vlr_Financiado { get; set; }
        [Required]
        [MaxLength(2)]
        [Column("SITUACAO")]
        public string Situacao { get; set; }
        [Required]
        [Column("DT_SITUACAO")]
        public DateTime Dt_Situacao { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("USUARIO")]
        public string Usuario { get; set; }
    }
}
