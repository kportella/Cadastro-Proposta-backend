using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Domain.Entities
{
    public class TreinaSituacaoEntity : BaseEntity
    {
        [Required]
        [Column("ID_TREINA_SITUACAO")]
        public int Id_Treina_Situacao { get; set; }
        [Key]
        [Required]
        [MaxLength(2)]
        [Column("SITUACAO")]
        public string Situacao { get; set; }
        [Required]
        [MaxLength(25)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
