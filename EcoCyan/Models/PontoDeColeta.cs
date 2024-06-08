using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EcoCyan.Models
{
    [Table("PONTO_DE_COLETA")]
    public class PontoDeColeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_ponto_col")]
        public int IdPontoColeta { get; set; }

        [Required]
        [StringLength(30)]
        [Column("nm_ponto_col")]
        public string NomePontoColeta { get; set; }

        [Required]
        [StringLength(150)]
        [Column("end_ponto_col")]
        public string EnderecoPontoColeta { get; set; }

        [Required]
        [StringLength(150)]
        [Column("contato_ponto_col")]

        public string ContatoPontoColeta { get; set; }

        [ForeignKey("entrega_lixo_id_entrega_lixo")]
        public int IdEntregaLixo { get; set; }
        public EntregaLixo EntregaLixo { get; set; }

    }
}
