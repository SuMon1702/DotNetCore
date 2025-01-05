using Microsoft.EntityFrameworkCore;
using SMDotNetCore.PizzaAPI.Model;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SMDotNetCore.PizzaAPI.DB;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<PizzaModel> Pizzas { get; set; }

    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }


}

public class OrderRequest
{
    public int PizzaId { get; set; }
    public int[] Extras { get; set; }
}
