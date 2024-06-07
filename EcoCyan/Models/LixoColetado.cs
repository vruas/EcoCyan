using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoCyan.Models
{
    [Table("lixo_coletado")]
    public class LixoColetado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_lixo_coletado")]
        public int IdLixoColetado { get; set; }

        [Required]
        [StringLength(15)]
        [Column("tp_lixo")]
        public string TipoLixo { get; set; }

        [Required]
        [StringLength(10)]
        [Column("quantidade_lixo")]
        public string QuantidadeLixo { get; set; }

        [Required]
        [StringLength(150)]
        [Column("local_coleta")]
        public string LocalColeta { get; set; }

        [ForeignKey("usuarios_id_user")]
        public int IdUser { get; set; }
        public Usuarios User { get; set; }

        public ICollection<EntregaLixo> EntregaLixo { get; set; }

    }
}
