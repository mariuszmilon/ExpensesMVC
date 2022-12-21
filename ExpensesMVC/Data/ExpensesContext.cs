using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMVC.Data
{
    public class ExpensesContext : IdentityDbContext<IdentityUser>
    {
        private readonly string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ExpensesDataBase;Trusted_Connection=True";

        public DbSet<Expense> Expenses { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .Property(p => p.Price)
                .HasColumnType("decimal(7, 2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
