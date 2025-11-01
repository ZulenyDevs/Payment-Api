using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Payments.CreatePayment;
using Payment.Application.Payments.GetPayments;

namespace Payment.WebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromBody] CreatePaymentCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return Ok(id);

            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetItems([FromQuery] Guid customerId)
        {
            try
            {
                var result = await _mediator.Send(new GetPaymentsQuery(customerId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
