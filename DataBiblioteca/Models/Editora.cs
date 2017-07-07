using System.ComponentModel.DataAnnotations;

namespace DataBiblioteca
{
    public class Editora
    {
        [Key]
        public int EditoraID { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
