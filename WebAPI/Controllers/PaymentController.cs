using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("pay")]
        public IActionResult Pay(PaymentRequest paymentRequest)
        {
            var result = _paymentService.Pay(paymentRequest);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
