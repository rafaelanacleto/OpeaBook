using OpeaBook.Domain.Entities;
using OpeaBook.Infra.Data.Context;
using OpeaBook.Infra.Data.Repositories.Interfaces;
using OpeaBook.Infra.Data;
using OpeaBook.Infrastructure.Repositories;

namespace OpeaBook.Infra.Data.Repositories
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}