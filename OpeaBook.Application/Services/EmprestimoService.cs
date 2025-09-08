using OpeaBook.Domain.Entities;
using OpeaBook.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeaBook.Application.Services
{
    public class EmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, ILivroRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _livroRepository = livroRepository;
        }

        public async Task<Emprestimo> SolicitarEmprestimo(int livroId)
        {
            var livro = await _livroRepository.GetByIdAsync(livroId);
            if (livro == null)
            {
                throw new ArgumentException("Livro não encontrado.");
            }

            if (livro.QuantidadeDisponivel <= 0)
            {
                throw new InvalidOperationException("Não há exemplares disponíveis para empréstimo.");
            }

            livro.ReduzirQuantidade();
            await _livroRepository.UpdateAsync(livro);

            var emprestimo = new Emprestimo(livroId);
            await _emprestimoRepository.AddAsync(emprestimo);

            return emprestimo;
        }

        public async Task DevolverEmprestimo(int emprestimoId)
        {
            var emprestimo = await _emprestimoRepository.GetByIdAsync(emprestimoId);
            if (emprestimo == null)
            {
                throw new ArgumentException("Empréstimo não encontrado.");
            }

            if (emprestimo.Status == EmprestimoStatus.Devolvido)
            {
                throw new InvalidOperationException("Este empréstimo já foi devolvido.");
            }

            emprestimo.Devolver();
            await _emprestimoRepository.UpdateAsync(emprestimo);

            var livro = await _livroRepository.GetByIdAsync(emprestimo.LivroId);
            if (livro != null)
            {
                livro.AumentarQuantidade();
                await _livroRepository.UpdateAsync(livro);
            }
        }

        public async Task<IEnumerable<Emprestimo>> ListarEmprestimos()
        {
            return await _emprestimoRepository.GetAllAsync();
        }
    }
}
