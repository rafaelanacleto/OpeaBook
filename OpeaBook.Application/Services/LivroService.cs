using OpeaBook.Domain.Entities;
using OpeaBook.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeaBook.Application.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<Livro> CriarLivro(string titulo, string autor, int anoPublicacao)
        {
            var livro = new Livro(titulo, autor, anoPublicacao);
            await _livroRepository.AddAsync(livro);
            return livro;
        }

        public async Task<Livro> ObterLivroPorId(int id)
        {
            return await _livroRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Livro>> ListarLivros()
        {
            return await _livroRepository.GetAllAsync();
        }
    }
}
