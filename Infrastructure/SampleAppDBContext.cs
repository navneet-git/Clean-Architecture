using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class SampleAppDBContext : DbContext
    {
        private IConfiguration _configuration;
        public readonly string _connectionString = string.Empty;

        public SampleAppDBContext() { }

        public SampleAppDBContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
            _connectionString = _configuration.GetConnectionString("SampleAppDb").ToString();
        }
        

        public SampleAppDBContext(DbContextOptions<SampleAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SampleApp;Trusted_Connection=True;Encrypt=False;");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                //entity.HasKey(p => p.Id).HasName("PK_User");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("ID");
            });
            //OnModelCreatingPartial(modelBuilder);
        }       
    }
}
