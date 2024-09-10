using Application.Ports;
using Application.Responses;
using Application.Room.Dtos;
using Application.Room.Ports;
using Application.Room.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace API.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomManager _roomManager;

        public RoomController(
            ILogger<RoomController> logger,
            IRoomManager roomManager
            )
        {
            _logger = logger;
            _roomManager = roomManager;
        }
        [HttpPost]
        public async Task<ActionResult<RoomDto>> Post(RoomDto room)
        {
            var request = new CreateRoomRequest()
            {
                Data = room
            };

            var result = await _roomManager.CreateRoom(request);

            if (result.Success) return Created("", result.Data);

            else if (result.ErrorCodes == ErrorCodes.ROOM_MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(result);
            }
            else if (result.ErrorCodes == ErrorCodes.ROOM_COULD_NOT_STORE_DATA)
            {
                return BadRequest(result);
            }

            _logger.LogError("Response with unknown ErrorCode Returned", result);
            return BadRequest(500);
        }
    }
}
