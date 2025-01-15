using Microsoft.EntityFrameworkCore;
using SMDotNetCore.PizzaAPI.Model;

namespace SMDotNetCore.PizzaAPI.DB
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<PizzaModel> Pizzas { get; set; }

        public DbSet<PizzaExtraModel> PizzaExtras { get; set; }

        public DbSet<PizzaOrderModel> PizzaOrders { get; set; }
        public DbSet<PizzaOrderDetailModel> PizzaOrderDetails { get; set; }

    }

    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extras { get; set; }
    }

    public class OrderResponse
    {
        public string Message { get; set; }
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class  PizzaOrderInvoiceResponse
    {
        public PizzaOrderInvoiceHeadModel Order { get; set; }
        public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
    }
}
