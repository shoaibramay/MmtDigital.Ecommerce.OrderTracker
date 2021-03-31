using MmtDigital.Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MmtDigital.Ecommerce.Services
{
    public interface IOrderService
    {
        Order GetLatestOrderByCustomerId(string customerId);
    }
}
