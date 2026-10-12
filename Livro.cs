using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBiblioteca
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; }

        public Livro()
        {
            Exemplares = new List<Exemplar>();
        }

        public Livro(int isbn) : this()
        {
            Isbn = isbn;
        }

        public Livro(int isbn, string titulo, string autor, string editora) : this(isbn)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            return Exemplares.Count(e => e.Disponivel());
        }

        public int QtdeEmprestimos()
        {
            return Exemplares.Sum(e => e.QtdeEmprestimos());
        }

        public double PercDisponibilidade()
        {
            int total = QtdeExemplares();
            if (total == 0) return 0.0;
            return ((double)QtdeDisponiveis() / total) * 100.0;
        }

        public override bool Equals(object obj)
        {
            if (obj is Livro outro)
            {
                return Isbn == outro.Isbn;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }
    }
}