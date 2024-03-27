using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUser.Models
{
    [Table("carros")]
    public class CarrosModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Marca { get; set; }
        [MaxLength(80)]
        public string Modelo { get; set; }
        
        public DateTime DataFabricacao { get; set; }
    }
}
