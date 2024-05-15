using Microsoft.EntityFrameworkCore;

namespace ApplicationMgt.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
            optionsBuilder.UseCosmos(connectionString, "ApplicationDb");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("Questions");

            builder.Entity<Question>()
                   .ToContainer(nameof(Question))
                   .HasPartitionKey(c => c.Id)
                   .HasNoDiscriminator();

            builder.Entity<ApplicationForm>()
                   .ToContainer(nameof(ApplicationForm))
                   .HasPartitionKey(c => c.Id)
                   .HasNoDiscriminator();

            builder.Entity<Candidate>()
                   .ToContainer(nameof(Candidate))
                   .HasPartitionKey(c => c.Id)
                   .HasNoDiscriminator();
        }
    }
}
