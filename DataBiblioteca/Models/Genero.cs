using System.ComponentModel.DataAnnotations;

namespace DataBiblioteca
{
    public class Genero
    {
        [Key]
        public int GeneroID { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
