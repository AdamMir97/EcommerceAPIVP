namespace ECommerceAPI.DataTransferObjects
{
    public class OrderDto
    {
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public List<OrderItemDto> OrderItem { get; set; }
    }
}
