using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Services;
using System.Threading.Tasks;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly OrdersService _ordersService;

        public string Message { get; private set; } = "Welcome to Demo Shop.";

        public string OrderStatus { get; set; }

        public IndexModel(OrdersService ordersService)
        {
            _ordersService = ordersService;

        }

        public async Task OnGetAsync()
        {
            //Message = await _ordersService.GetSomeText("aGVsbG8gd29ybGQK");            
        }

        public async Task OnPostAsync()
        {

        }
    }
}