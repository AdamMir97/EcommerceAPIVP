using ECommerceAPI.Models;
using ECommerceAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.DataTransferObjects;


namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDbContext _dbContext;

        //using dependency injection
        public OrdersController(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult Create(OrderDto orderDto)
        {
            // Check that OrderItem isn't empty
            if (orderDto.OrderItem.Count == 0)
            {
                return BadRequest("Invalid request, add a product.");
            }
            // Check if the product quantity is greater than 0
            if (orderDto.OrderItem.Any(oi => oi.Quantity <= 0))
            {
                return BadRequest("Invalid product quantity.");
            }

            // Check if address contains strange characters
            if (orderDto.CustomerAddress.Contains("=") || orderDto.CustomerAddress.Contains(";"))
            {
                return BadRequest("Invalid address");
            }

            //TODO expand on this
            var order = new Order
            {
                CustomerEmail = orderDto.CustomerEmail,
                CustomerAddress = orderDto.CustomerAddress,
                OrderItem = orderDto.OrderItem.Select(dto =>
                    new OrderItem
                    {
                        ProductName = dto.ProductName,
                        Quantity = dto.Quantity,
                        Price = dto.Price
                    }).ToList()
            };

            

            Console.WriteLine(orderDto.CustomerEmail);
            Console.WriteLine(orderDto.CustomerAddress);
            foreach (var item in orderDto.OrderItem)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Quantity);
                Console.WriteLine(item.Price);
            }
            

            //_dbContext.Orders.Add(order);
            //_dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
