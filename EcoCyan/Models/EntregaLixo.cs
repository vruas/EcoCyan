using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoCyan.Models
{
    [Table("entrega_lixo")]
    public class EntregaLixo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_entrega_lixo")]
        public int IdEntregaLixo { get; set; }

        [Required]
        [StringLength(10)]
        [Column("dt_entrega")]
        public string DataEntrega { get; set; }

        [ForeignKey("lixo_coletado_id_lixo_coletado")]
        public int IdLixoColetado { get; set; }
        public LixoColetado lixoColetado { get; set; }

        [ForeignKey("lixo_coletado_id_user")]
        public int IdUser { get; set; }
        public Usuarios User { get; set; }

        public ICollection<PontoDeColeta> PontoDeColeta { get; set; }


    }
}
