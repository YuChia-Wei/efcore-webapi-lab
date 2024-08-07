using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.Lab.Repository;

public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
{
    public SampleDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=SampleDb;Persist Security Info=False;User ID=SA;Password=<YourStrong@Passw0rd>;Pooling=True;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=True");

        return new SampleDbContext(optionsBuilder.Options);
    }
}