using Microsoft.EntityFrameworkCore;
using MmtDigital.Ecommerce.Data;
using MmtDigital.Ecommerce.Entities;
using System.Linq;

namespace MmtDigital.Ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationContext _applicationContext;

        public OrderService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public Order GetLatestOrderByCustomerId(string customerId)
        {
            var result = _applicationContext.Orders
                .Where(a => a.CustomerId == customerId)
                .Include(b => b.OrderItems)
                .ThenInclude(c => c.Product)
                .OrderByDescending(x => x.OrderDate).FirstOrDefault();
            return result;
        }
    }
}
