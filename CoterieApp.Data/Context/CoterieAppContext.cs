using AssesmentCoterie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoterieApp.Data.Context
{
    public class CoterieAppContext: DbContext
    {
        public CoterieAppContext(DbContextOptions<CoterieAppContext> options): base(options) { }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Business> Businesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("NOCASE");
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<Business>(b =>
            {
                b.HasKey(b => b.Id);
            });
            modelBuilder.Entity<Quote>().ToTable("Quotes");
            modelBuilder.Entity<Quote>(q =>
            {
                q.HasKey(q => q.TransactionId);                
            });
            modelBuilder.Entity<State>().ToTable("States");
            modelBuilder.Entity<State>(s =>
            {
                s.HasKey(s => s.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
