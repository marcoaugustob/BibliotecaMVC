using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaData
{
    public class Livro
    {
        public int Id{ get; set; }
        //[Required]
        public string Nome { get; set; }
        //[Required]
        public string Editora { get; set; }
        public string Genero { get; set; }
        public DateTime Ano { get; set; }
        //[Required]
        public bool Emprestado{ get; set; }
        //[Required]
        public Prateleira Prateleira { get; set; }

    }
}
