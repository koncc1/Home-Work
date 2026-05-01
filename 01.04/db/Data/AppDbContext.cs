using db.Models;
using Microsoft.EntityFrameworkCore;

namespace db.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) // передаємо настройки в DbContext
        {
        }

        // Таблиця Users в БД
        public DbSet<User> Users { get; set; }
    }
}