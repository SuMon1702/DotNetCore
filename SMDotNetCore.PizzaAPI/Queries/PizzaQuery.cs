namespace SMDotNetCore.PizzaAPI.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = @"
            SELECT 
                po.*,
                p.Pizza,
                p.Price
            FROM Tbl_PizzaOrder po
            INNER JOIN Tbl_Pizza p ON po.PizzaId = p.PizzaId
            WHERE po.PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }


}


