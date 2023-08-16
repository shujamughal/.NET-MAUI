using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoAppMaui.Shared;

namespace TodoAppMaui.Database
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                              
            optionsBuilder.UseSqlServer("Data Source=SHUJA\\SQLEXPRESS;Initial Catalog=ToDoApp;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}