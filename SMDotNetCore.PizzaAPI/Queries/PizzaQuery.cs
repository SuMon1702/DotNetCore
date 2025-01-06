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



        public static string PizzaOrderDetailQuery { get; } = @"
            SELECT 
                pod.*,
                pe.PizzaExtraName,
                pe.Price
            FROM Tbl_PizzaOrderDetail pod
            INNER JOIN Tbl_Extra pe ON pod.PizzaExtraId = pe.PizzaExtraId
            WHERE pod.PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";

    }
}


