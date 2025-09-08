using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpeaBook.Domain.Entities;
using System.Reflection.Emit;

namespace OpeaBook.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração das entidades, se necessário.
            // Exemplo:
            builder.Entity<Livro>().HasKey(l => l.Id);
            builder.Entity<Livro>().Property(l => l.Titulo).IsRequired();
            builder.Entity<Livro>().Property(l => l.Autor).IsRequired();

            builder.Entity<Emprestimo>().HasKey(e => e.Id);
            builder.Entity<Emprestimo>().Property(e => e.DataEmprestimo).IsRequired();
            builder.Entity<Emprestimo>().Property(e => e.Status).IsRequired();
        }
    }
}