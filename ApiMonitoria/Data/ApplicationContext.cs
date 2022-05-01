using Microsoft.EntityFrameworkCore;

namespace ApiMonitoria.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0N5LR8U\MSSQLSERVER02;Initial Catalog=MonitoriaWEBAPI;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(table =>
            {
                table.ToTable("Clientes");
                table.Property("Nome").HasMaxLength(40);
                table.Property("CPF").HasColumnType("CHAR(11)");
                table.Property("Nascimento").HasColumnType("DATE"); 
                table.HasKey("Id");
            });
        }
    }
}