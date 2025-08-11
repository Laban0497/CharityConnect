using CharityConnect.Application.DTOs.Payments;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnectAPI.Controllers.Payments
{
    [ApiController]
    [Route("api/payments")]
    [Authorize(Roles = "Donor")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("stkpush")]
        public async Task<IActionResult> StkPush([FromBody] StkPushRequestDTO dto)
        {
            var result = await _paymentService.InitiateStkPushAsync(dto);
            return Ok(result);
        }

        [HttpPost("callback")]
        [AllowAnonymous]
        public async Task<IActionResult> Callback([FromBody] object payload)
        {
            await _paymentService.HandleCallbackAsync(payload.ToString()!);
            return Ok();
        }
    }
}
