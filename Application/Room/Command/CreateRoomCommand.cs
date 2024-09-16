using Application.Room.Dtos;
using Application.Room.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Command
{
    public class CreateRoomCommand : IRequest<RoomResponse>
    {
        public RoomDto RoomDto { get; set; }
    }
}
