using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private IGuestRepository _guestRepository;
        public GuestManager(IGuestRepository guestRepository) 
        {
            _guestRepository = guestRepository;
        }
        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);
                request.Data.Id = await _guestRepository.Create(guest);
                return new GuestResponse
                {
                    Data = request.Data,
                    Sucess = true,
                };           
            } catch (Exception) 
            {
                return new GuestResponse
                {
                    Sucess = false,
                    ErrorCodes = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to db"
                };
            }
        }
    }
}
