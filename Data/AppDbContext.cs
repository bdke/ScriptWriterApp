using Microsoft.EntityFrameworkCore;

namespace ScriptWriterApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<ChangeHistory> ChangeHistories { get; set; }

        public DbSet<PagesData> PagesDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChangeHistory>().HasData(new List<ChangeHistory>());
            modelBuilder.Entity<TextsData>().HasData(new List<TextsData>());
            modelBuilder.Entity<PagesData>().HasData(new List<PagesData>() { new PagesData() { ID = 1 ,Path = "/", Texts = "my mom is beautiful", pTexts = "" } });
        }
    }
}
