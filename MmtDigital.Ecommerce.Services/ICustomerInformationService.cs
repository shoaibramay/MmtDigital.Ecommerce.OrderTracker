using System;
using System.Threading.Tasks;
using MmtDigital.Ecommerce.Entities;

namespace MmtDigital.Ecommerce.Services
{
    public interface ICustomerInformationService
    {
        Task<Customer> GetCustomerInformationAsync(string id);
    }
}
