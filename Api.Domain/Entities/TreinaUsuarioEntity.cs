using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Domain.Entities
{
    public class TreinaUsuarioEntity : BaseEntity
    {
        [Required]
        [Column("ID_TREINA_USUARIO")]
        public int Id_Treina_Usuario { get; set; }
        [Key]
        [Required]
        [MaxLength(10)]
        [Column("USUARIO")]
        public string Usuario { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("SENHA")]
        public string Senha { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("NOME")]
        public string Nome { get; set; }
        [Column("DATA_VALIDADE")]
        public DateTime Data_Validade { get; set; }

    }
}
