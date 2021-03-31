using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using MmtDigital.Ecommerce.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MmtDigital.Ecommerce.Services
{
    public class CustomerInformationService : ICustomerInformationService
    {
        private readonly IConfiguration Configuration;

        public CustomerInformationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<Customer> GetCustomerInformationAsync(string id)
        {
            try
            {
                Customer customer = null;
                using (var httpClient = new HttpClient())
                {
                    var query = new Dictionary<string, string>
                    {
                        ["code"] = Configuration["ApiCode"],
                        ["email"] = id
                    };

                    using (var response = await httpClient.GetAsync(QueryHelpers.AddQueryString(Configuration["ApiUrl"], query)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                        }

                    }
                }

                return customer;

            }
            catch
            {
                return null;
            }

        }
    }
}
