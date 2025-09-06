using System;
using OpeaBook.Domain.Base;

namespace OpeaBook.Domain.Entities
{
    public class Livro : Entity
    {
        public string? Titulo { get; private set; }
        public string? Autor { get; private set; }
        public DateTime? DataPublicacao { get; set; }
        public string? Isbn { get; set; }
        public int NumeroPaginas { get; set; } = 0;
        public int QuantidadeEstoque { get; private set; } = 0;

        public Livro(string titulo, string autor, DateTime? dataPublicacao = null, string? isbn = null, int numeroPaginas = 0, int quantidadeEstoque = 0)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.", nameof(titulo));
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor não pode ser vazio.", nameof(autor));

            Titulo = titulo;
            Autor = autor;
            DataPublicacao = dataPublicacao;
            Isbn = isbn;
            NumeroPaginas = numeroPaginas;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void RealizarEmprestimo()
        {
            if (QuantidadeEstoque <= 0)
                throw new InvalidOperationException("Não há exemplares disponíveis para empréstimo.");
            QuantidadeEstoque--;
        }

        public void RealizarDevolucao()
        {
            QuantidadeEstoque++;
        }
    }
}