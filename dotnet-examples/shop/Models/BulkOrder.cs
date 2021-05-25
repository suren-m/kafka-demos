using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{

    public class BulkOrder
    {
        // [Required, Range(1, 200)]
        public int Count { get; set; }
    }

}