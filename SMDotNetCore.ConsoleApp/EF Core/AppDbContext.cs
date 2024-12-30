using Microsoft.EntityFrameworkCore;
using SMDotNetCore.ConsoleApp.Appsettings;
using SMDotNetCore.ConsoleApp.Models;

namespace SMDotNetCore.ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<MovieModel> Movies { get; set; }


    }
}
