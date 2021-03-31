using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MmtDigital.Ecommerce.Entities;
using MmtDigital.Ecommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MmtDigital.Ecommerce.Data;
using AutoMapper;

namespace MmtDigital.Ecommerce.OrderTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase
    {
        private readonly ICustomerInformationService _customerInformationService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderTrackerController(ICustomerInformationService customerInformationService, IOrderService orderService, IMapper mapper)
        {
            _customerInformationService = customerInformationService;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            Customer customer = await _customerInformationService.GetCustomerInformationAsync("cat.owner@mmtdigital.co.uk");

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerPostRequestModel model)
        {

            Customer customer = await _customerInformationService.GetCustomerInformationAsync(model.User);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {

                OrderTrackerViewModel tracker = new OrderTrackerViewModel();
                tracker.Customer = customer;

                //try to get order if any
                Order latestOrder = _orderService.GetLatestOrderByCustomerId(customer.CustomerId);
                _mapper.Map(latestOrder, tracker.Order);

                return Ok(tracker);
            }


        }
    }
}
