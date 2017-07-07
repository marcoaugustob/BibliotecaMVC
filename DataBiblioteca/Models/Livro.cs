using System.ComponentModel.DataAnnotations;

namespace DataBiblioteca
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int GeneroID { get; set; }
        public virtual Genero _Genero { get; set; }
        [Required]
        public bool Emprestado { get; set; }
        [Required]
        public int PrateleiraID { get; set; }
        public virtual Prateleira _Prateleira { get; set; }
        [Required]
        public int EditoraID { get; set; }
        public virtual Editora _Editora { get; set; }
    }
}
