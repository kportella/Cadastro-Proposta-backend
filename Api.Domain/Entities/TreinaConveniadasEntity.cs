using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Domain.Entities
{
    public class TreinaConveniadasEntity : BaseEntity
    {
        [Required]
        [Column("ID_TREINA_CONVENIADA")]
        public int Id_Treina_Conveniada { get; set; }
        [Key]
        [Required]
        [MaxLength(6)]
        [Column("CONVENIADA")]
        public string Conveniada { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
