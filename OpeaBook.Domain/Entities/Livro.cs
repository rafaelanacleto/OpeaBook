namespace OpeaBook.Domain.Entities
{
    public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int AnoPublicacao { get; private set; }
        public int QuantidadeDisponivel { get; private set; }

        // Construtor privado para ser utilizado apenas pelo ORM (Entity Framework)
        private Livro() { }

        public Livro(string titulo, string autor, int anoPublicacao)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException("O título não pode ser vazio.", nameof(titulo));
            }

            if (string.IsNullOrWhiteSpace(autor))
            {
                throw new ArgumentException("O autor não pode ser vazio.", nameof(autor));
            }

            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            QuantidadeDisponivel = 0;
        }

        public void AdicionarExemplares(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));
            }
            QuantidadeDisponivel += quantidade;
        }

        public void ReduzirQuantidade()
        {
            if (QuantidadeDisponivel <= 0)
            {
                throw new InvalidOperationException("Não há exemplares disponíveis para empréstimo.");
            }
            QuantidadeDisponivel--;
        }

        public void AumentarQuantidade()
        {
            QuantidadeDisponivel++;
        }
    }
}