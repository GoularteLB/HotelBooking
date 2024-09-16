using Application.Room.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Queries
{
    public class GetRoomQuery : IRequest<RoomResponse>
    {
        public int Id { get; set; }
    }
}

