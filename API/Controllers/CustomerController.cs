using API.Dto;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : BaseContoller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);

            if(customer == null) return NotFound("Customer not found");

            return Ok(customer);
        }
    }
}
