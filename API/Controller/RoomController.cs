using Application.Ports;
using Application.Responses;
using Application.Room.Command;
using Application.Room.Dtos;
using Application.Room.Ports;
using Application.Room.Queries;
using Application.Room.Request;
using MediatR;
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
        private readonly IMediator _mediator;

        public RoomController(
            ILogger<RoomController> logger,
            IRoomManager roomManager,
             IMediator mediator
            )
        {
            _logger = logger;
            _roomManager = roomManager;
            _mediator = mediator;
        }
          [HttpPost]
        public async Task<ActionResult<RoomDto>> Post(RoomDto room)
        {
            var request = new CreateRoomCommand
            {
                RoomDto = room
            };

            var result = await _mediator.Send(request);

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
        [HttpGet]
        public async Task<ActionResult<RoomDto>> Get(int roomId)
        {
            var query = new GetRoomQuery
            {
                Id = roomId
            };

            var res = await _mediator.Send(query);

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }
    }
}
