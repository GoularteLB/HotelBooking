using Application;
using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{

    [ApiController]
    [Route("[Controller]")]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(
            ILogger<GuestController> logger, 
            IGuestManager guestManager
            )
        {
            _logger = logger;
            _guestManager = guestManager;
        }
        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };
            var rest = await _guestManager.CreateGuest(request);

            if (rest.Sucess) return Created("", rest.Data);

            if (rest.ErrorCodes == ErrorCodes.NOT_FOUND)
            {
                return BadRequest(rest);
            }

            _logger.LogError("Response with unknown ErrorCode return", rest);
                return BadRequest(500);

        }
    }
}
