using OpeaBook.Domain.Base;

namespace OpeaBook.Domain.Entities
{
    public class Emprestimo : Entity
    {
        public Guid LivroId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public StatusEnum Status { get; private set; }

        public Emprestimo(Livro livro)
        {
            if (livro == null)
                throw new ArgumentNullException(nameof(livro));

            livro.RealizarEmprestimo(); // lança exceção se não houver exemplar disponível

            LivroId = livro.Id;
            DataEmprestimo = DateTime.Now;
            Status = StatusEnum.Ativo;
        }

        public void RealizarDevolucao(Livro livro)
        {
            if (Status == StatusEnum.Devolvido)
                throw new InvalidOperationException("Livro já foi devolvido.");

            DataDevolucao = DateTime.Now;
            Status = StatusEnum.Devolvido;
        }
    }
}