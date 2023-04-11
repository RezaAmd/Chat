using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Chat.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //In this case, the predicate will scan the types and for each type, will check if it implements the IEntityTypeConfiguration<T> interface and if T inherits BaseEntity.
        //https://stackoverflow.com/questions/61430833/applyconfigurationsfromassembly-with-filter-entityframework-core
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"), options =>
        {
            options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
    }

    #region Tables
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    #endregion
}