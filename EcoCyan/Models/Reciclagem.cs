using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EcoCyan.Models
{
    [Table("reciclagem")]
    public class Reciclagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_reciclagem")]
        public int IdReciclagem { get; set; }

        [Required]
        [StringLength(10)]
        [Column("dt_reciclagem")]
        public string DataReciclagem { get; set; }

        [Required]
        [StringLength(10)]
        [Column("quantidade_reciclada")]
        public string QuantidadeReciclada { get; set; }

        [ForeignKey("usuarios_id_user")]
        public int IdUser { get; set; }
        public Usuarios User { get; set; }


    }
}
