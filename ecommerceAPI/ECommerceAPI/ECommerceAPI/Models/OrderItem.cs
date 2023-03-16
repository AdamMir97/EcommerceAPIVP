using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //foreign keys
        public virtual int OrderId { get; set; }
        [ForeignKey("OrderId")]
        //each OrderItem belongs to one Order
        //virtual as it's a navigation property
        public virtual Order Order { get; set; }
    }
}
