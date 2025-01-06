using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMDotNetCore.PizzaAPI.DB;
using SMDotNetCore.PizzaAPI.Model;
using SMDotNetCore.PizzaAPI.Queries;
using SMDotNetCore.shared;

namespace SMDotNetCore.PizzaAPI.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly DapperService _dapperService;
        public PizzaController()
        {
            _context = new AppDbContext();
            _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _context.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _context.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Orders/{invoiceNo}")]
        public async Task<IActionResult> GetOrders(string invoiceNo)
        {
            var item = await _context.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            var lst = await _context.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

            return Ok(new
            {
                Order = item,
                OrderDetail = lst
            });
        }


        [HttpGet ("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
            (
                PizzaQuery.PizzaOrderQuery,
                new { PizzaOrderInvoiceNo = invoiceNo }
            );

            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
                (
                    PizzaQuery.PizzaOrderDetailQuery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };

            return Ok(model);
        }
        
        
        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _context.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza!.price!;

            if (orderRequest.Extras.Length >0)
            {
                // select * from Tbl_PizzaExtras where PizzaExtraId in (1,2,3,4)
                //foreach (var item in orderRequest.Extras)
                //{
                //}

                var lstExtra = await _context.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };
            List<PizzaOrderDetailModel> PizzaExtraModel = orderRequest.Extras.Select(ExtraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = ExtraId,
                PizzaOrderInvoiceNo = invoiceNo,
            }).ToList();

            await _context.PizzaOrders.AddAsync(pizzaOrderModel);
            await _context.PizzaOrderDetails.AddRangeAsync(PizzaExtraModel);
            await _context.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order! Enjoy your pizza!",
                TotalAmount = total,
            };

            return Ok(response);


        }
    }
}
