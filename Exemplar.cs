using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoBiblioteca
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public Exemplar()
        {
            Emprestimos = new List<Emprestimo>();
        }

        public Exemplar(int tombo) : this()
        {
            Tombo = tombo;
        }

        public bool Disponivel()
        {
            if (Emprestimos.Count == 0)
                return true;

            return Emprestimos.Last().DtDevolucao != DateTime.MinValue;
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            if (!Disponivel())
            {
                Emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is Exemplar outro)
            {
                return Tombo == outro.Tombo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Tombo.GetHashCode();
        }
    }
}