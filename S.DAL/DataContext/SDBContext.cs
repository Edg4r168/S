using Microsoft.EntityFrameworkCore;
using S.EN;

namespace S.DAL.DataContext;

public class SDBContext : DbContext
{

    public DbSet<PersonaS> PersonasS { get; set; }

    public SDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaS>().ToTable("PersonasS");

        modelBuilder.Entity<PersonaS>()
                .Property(p => p.SueldoS)
                .HasColumnType("decimal(18,2)");
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_dbConnectionString, sqlServerOptions =>
    //    {
    //        sqlServerOptions.EnableRetryOnFailure(
    //            maxRetryCount: 5,
    //            maxRetryDelay: TimeSpan.FromSeconds(30),
    //            errorNumbersToAdd: null
    //        );
    //    });
    //}
}
