using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using System.Data.Entity;

namespace ECommerceAPI.DataAccess
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        //pass options to constructor
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }        

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        
    }
}
