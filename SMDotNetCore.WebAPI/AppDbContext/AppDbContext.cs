using Microsoft.EntityFrameworkCore;
using SMDotNetCore.WebAPI.Model;

namespace SMDotNetCore.WebAPI.AppDbContext
{
    internal class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
