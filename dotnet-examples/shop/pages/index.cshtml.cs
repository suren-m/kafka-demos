using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly OrdersService _ordersService;

        public string Message { get; private set; } = "Welcome to the Shop.";

        public string OrderStatus { get; set; }

        public IndexModel(OrdersService ordersService)
        {
            _ordersService = ordersService;

        }

        public async Task OnGetAsync()
        {
            Message = await _ordersService.GetSomeText("aGVsbG8gd29ybGQK");
        }

        public async Task OnPostAsync()
        {

        }
    }
}