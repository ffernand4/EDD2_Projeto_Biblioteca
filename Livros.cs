using System.Collections.Generic;
using System.Linq;

namespace ProjetoBiblioteca
{
    public class Livros
    {
        public List<Livro> Acervo { get; set; }

        public Livros()
        {
            Acervo = new List<Livro>();
        }

        public void Adicionar(Livro livro)
        {
            if (!Acervo.Contains(livro))
            {
                Acervo.Add(livro);
            }
        }

        public Livro Pesquisar(Livro livro)
        {
            return Acervo.FirstOrDefault(l => l.Equals(livro));
        }
    }
}