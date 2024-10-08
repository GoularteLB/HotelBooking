﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Responses;
using Application.Guest.Requests;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> CreateGuest(CreateGuestRequest request);
        Task<GuestResponse> GetGuest(int guestId);
    }
}
