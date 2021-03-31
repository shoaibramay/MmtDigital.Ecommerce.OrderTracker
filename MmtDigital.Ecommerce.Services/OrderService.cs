using MmtDigital.Ecommerce.Data;
using MmtDigital.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var result =  _applicationContext.Orders.Where(x => x.Customerid == customerId).OrderByDescending(y => y.Orderdate).FirstOrDefault();
            return result;
        }
    }
}
