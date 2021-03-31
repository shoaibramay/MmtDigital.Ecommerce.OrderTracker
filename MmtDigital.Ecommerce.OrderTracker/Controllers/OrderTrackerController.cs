using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MmtDigital.Ecommerce.Entities;
using MmtDigital.Ecommerce.Services;
using System;
using System.Threading.Tasks;

namespace MmtDigital.Ecommerce.OrderTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderTrackerController : ControllerBase
    {
        private readonly ICustomerInformationService _customerInformationService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderTrackerController(ICustomerInformationService customerInformationService, IOrderService orderService, IMapper mapper, ILogger<OrderTrackerController> logger)
        {
            _customerInformationService = customerInformationService;
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
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
            try
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
                    tracker.Order = _mapper.Map<OrderViewModel>(latestOrder);

                    if (latestOrder.ContainsGift == true)
                    {
                        tracker.Order.OrderItems.ForEach(n => { n.Product = "Gift"; });
                    }

                    return Ok(tracker);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }






        }
    }
}
