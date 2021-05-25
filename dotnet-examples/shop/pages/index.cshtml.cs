using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "Welcome to the Shop.";

        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
    }
}