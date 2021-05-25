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

        // public async Task OnPostAsync()
        // {
        //     if (BulkOrder.Count <= 1)
        //     {
        //         await _ordersService.PlaceOrderAsync(OrderType.Default);
        //         OrderStatus = "Single Order placed";
        //     }
        //     else
        //     {
        //         _ordersService.PlaceBulkOrders(BulkOrder.Count);
        //         OrderStatus = "Bulk Order placed";
        //     }
        // }

        public async Task OnPostSingleOrder()
        {
            await _ordersService.PlaceOrderAsync(OrderType.Default);
            OrderStatus = "Single Order placed";
        }

        public async Task OnPostBulkOrder()
        {
            _ordersService.PlaceBulkOrders(BulkOrder.Count);
            OrderStatus = "Bulk Order placed";
        }
    }
}