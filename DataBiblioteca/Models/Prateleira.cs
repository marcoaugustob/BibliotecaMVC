
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBiblioteca
{
    public class Prateleira
    {
        [Key]
        public int PrateleiraID { get; set; }
        [Required]
        public string Localizacao { get; set; }
        public virtual List<Livro> Livros { get; set; }

    }
}
