using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class TreinaClientesEntity : BaseEntity
    {
        [Required]
        [Column("ID_TREINA_CLIENTE")]
        public int Id_Treina_Cliente { get; set; }
        [Key]
        [Required]
        [MaxLength(11)]
        [Column("CPF")]
        public string CPF { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("NOME")]
        public string Nome { get; set; }
        [Required]
        [Column("DT_NASCIMENTO")]
        public DateTime Dt_Nascimento { get; set; }
        [Required]
        [Column("GENERO")]
        public char Genero { get; set; }
        [Required]
        [Column("VLR_SALARIO")]
        public float Vlr_Salario { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }
        [Required]
        [MaxLength(10)]
        [Column("NUMERO_RESIDENCIA")]
        public string Numero_Residencia { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("BAIRRO")]
        public string Bairro { get; set; }
        [Required]
        [MaxLength(60)]
        [Column("CIDADE")]
        public string Cidade { get; set; }
        [Required]
        [MaxLength(8)]
        [Column("CEP")]
        public string CEP { get; set; }
    }
}
