namespace SMDotNetCore.PizzaAPI.Model
{
    public class PizzaOrderInvoiceHeadModel
    {
        public string PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public string PizzaId { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }

    }
}
