using System;

namespace ProjetoBiblioteca
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime DtDevolucao { get; set; }

        public Emprestimo()
        {
            DtEmprestimo = DateTime.Now;
            DtDevolucao = DateTime.MinValue; // Indica empréstimo em aberto
        }

        public Emprestimo(DateTime dtEmprestimo)
        {
            DtEmprestimo = dtEmprestimo;
            DtDevolucao = DateTime.MinValue;
        }
    }
}