﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Guest.DTO;
using Application.Ports;
using Application.Guest.Requests;
using Application.Responses;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Guest
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
                await guest.Save(_guestRepository);
                request.Data.Id = guest.Id;
                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (InvalidPersonDocumentIdException)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.INVALID_PERSON_ID,
                    Message = "The Id passed is not valid"
                };
            }
            catch (MissingRequiredInformation)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing required information passed"
                };
            }
            catch (InvalidEmailException )
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.INVALID_EMAIL,
                    Message = "The Email is not valid"
                };
            }
            catch (Exception)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to db"
                };
            }
        }
        public async Task<GuestResponse> GetGuest(int guestId)
        {
            var guest = await _guestRepository.Get(guestId);

            if (guest == null)
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.GUEST_NOT_FOUND,
                    Message = "No Guest record was guest id"
                };
            }
            return new GuestResponse
            {
                Data = GuestDTO.MapToDto(guest),
                Success = true,
            };
        }
    }
}
