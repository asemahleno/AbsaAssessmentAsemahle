namespace ABSA.Corporate.Investment.PhoneBook.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Models;


    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Domain.Models.PhoneBook> PhoneBooks { get; set; }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Absa");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Models.PhoneBook>().HasKey(e => e.Id).IsClustered();
            modelBuilder.Entity<Entry>().HasKey(e => e.Id).IsClustered();
        }
    }
}
