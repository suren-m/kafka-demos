using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Models;
using Shop.Services;
using System.Threading.Tasks;

namespace Shop.Pages
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly OrdersService _ordersService;

        public string Message { get; private set; } = "Welcome to Demo Shop.";

        public string OrderStatus { get; set; }

        [BindProperty]
        public BulkOrder BulkOrder { get; set; }

        public IndexModel(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task OnPostSingleOrder()
        {
            await _ordersService.PlaceOrderAsync();
            //await _ordersService.PlaceOrderAsyncEH();
            OrderStatus = "Single Order placed";
        }

        public async Task OnPostBulkOrder()
        {
            _ordersService.PlaceBulkOrders(BulkOrder.Count);
            //_ordersService.PlaceBulkOrdersUsingEventHub(BulkOrder.Count);
            OrderStatus = "Bulk Order placed";
        }
    }
}