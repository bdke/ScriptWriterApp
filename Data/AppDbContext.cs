using Microsoft.EntityFrameworkCore;

namespace ScriptWriterApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ChangeHistory> ChangeHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<ChangeHistory> ChangeHistories = new List<ChangeHistory>();
            List<TextsData> TextsDatas = new List<TextsData>();

            modelBuilder.Entity<ChangeHistory>().HasData(ChangeHistories);
            modelBuilder.Entity<TextsData>().HasData(TextsDatas);
        }
    }
}
