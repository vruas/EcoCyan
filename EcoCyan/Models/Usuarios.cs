using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EcoCyan.Models
{
    [Table("USUARIOS")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_user")]
        public int IdUser { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nm_user")]
        public string NomeUser { get; set; }

        [Required]
        [StringLength(150)]
        [Column("email_user")]
        public string EmailUser { get; set; }

        [Required]
        [StringLength(30)]
        [Column("senha_user")]
        public string SenhaUser { get; set; }

        [Required]
        [StringLength(10)]
        [Column("tp_user")]
        public string TipoUser { get; set; }

        public ICollection<EntregaLixo> EntregaLixo { get; set; }
        public ICollection<LixoColetado> LixoColetado { get; set; }
        public ICollection<Reciclagem> Reciclagems { get; set; }

        
    }
}
