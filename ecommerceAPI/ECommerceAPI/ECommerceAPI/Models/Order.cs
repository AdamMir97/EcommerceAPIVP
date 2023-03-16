using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        //keeping address simple for the sake of brevity
        [Required]
        public string CustomerAddress { get; set; }

        //1 to many relationshp: each Order has multiple OrderItems
        //virtual as it's a navigation property
        [Required]
        public virtual List<OrderItem> OrderItem { get; set; }


                   
    }

}
