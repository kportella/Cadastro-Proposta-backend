using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Domain.Entities
{
    public class TreinaLimiteIdadeConveniadaEntity : BaseEntity
    {
        [Required]
        [Column("ID_TREINA_LIM_IDADE_CONVENIADA")]
        public int Id_Treina_Lim_Idade_Conveniada { get; set; }
        [Required]
        [MaxLength(6)]
        [Column("CONVENIADA")]
        public string Conveniada { get; set; }
        [Required]
        [Column("IDADE_INICIAL")]
        public int Idade_Inicial { get; set; }
        [Required]
        [Column("IDADE_FINAL")]
        public int Idade_Final { get; set; }
        [Required]
        [Column("VALOR_LIMITE")]
        public float Valor_Limite { get; set; }
        [Required]
        [Column("PERCENTUAL_MAXIMO_ANALISE")]
        public float Percentual_Maximo_Analise { get; set; }
    }
}
