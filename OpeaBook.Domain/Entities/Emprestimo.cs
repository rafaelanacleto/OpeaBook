using System;

namespace OpeaBook.Domain.Entities
{
    public enum EmprestimoStatus
    {
        Ativo,
        Devolvido
    }

    public class Emprestimo
    {
        public int Id { get; private set; }
        public int LivroId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public EmprestimoStatus Status { get; private set; }

        // Construtor privado para ser utilizado apenas pelo ORM (Entity Framework)
        private Emprestimo() { }

        public Emprestimo(int livroId)
        {
            LivroId = livroId;
            DataEmprestimo = DateTime.Now;
            Status = EmprestimoStatus.Ativo;
        }

        public void Devolver()
        {
            if (Status == EmprestimoStatus.Devolvido)
            {
                throw new InvalidOperationException("Este empréstimo já foi devolvido.");
            }

            DataDevolucao = DateTime.Now;
            Status = EmprestimoStatus.Devolvido;
        }
    }
}