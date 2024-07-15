using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PayamEvents;


namespace Payam.Consumers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayamController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PayamController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> SendPayam([FromBody] PayamMessage message)
        {

            if (message.PhoneNumbers == null || message.PhoneNumbers.Length == 0)
            {
                return BadRequest("PhoneNumbers array cannot be null or empty.");
            }

            await _publishEndpoint.Publish(message);
            return Ok("Message published successfully.");
        }
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return Ok("healthy");
        }
    }
}