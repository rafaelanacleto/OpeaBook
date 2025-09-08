using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpeaBook.Infra.Data.Context;
using OpeaBook.Infra.Data;

namespace OpeaBook.Infra.Data.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // This is a simple, hardcoded connection string for design time.
        // For a more robust solution, you could read from appsettings.json
        // or a different configuration file.
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=OpeaBookDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}