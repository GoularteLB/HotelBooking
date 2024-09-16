using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public enum ErrorCodes
    {
        NOT_FOUND = 1,
        COULD_NOT_STORE_DATA = 2,
        INVALID_PERSON_ID = 3,
        MISSING_REQUIRED_INFORMATION = 4,
        INVALID_EMAIL= 5,
        GUEST_NOT_FOUND = 6,

        
        ROOM_NOT_FOUND = 100,
        ROOM_COULD_NOT_STORE_DATA = 101,
        ROOM_INVAID_PERSON_ID= 102,
        ROOM_MISSING_REQUIRED_INFORMATION = 103,
        ROOM_INVALID_EMAIL = 104,
        ROOM_GUEST_NOT_FOUND = 105,

        BOOKING_NOT_FOUND = 200,
        BOOKING_COULD_NOT_STORE_DATA = 201,
        BOOKING_INVALID_PERSON_ID = 202,
        BOOKING_MISSING_REQUIRED_INFORMATION = 203,
        BOOKING_INVALID_EMAIL = 204,
        BOOKING_GUEST_NOT_FOUND = 205,
        BOOKING_ROOM_CANNOT_BE_BOOKED = 206,


        //Payment relate codes 500 - 1500
        PAYMENT_INVALIDPAYMENT_INTENTION = 500,
        PAYMENT_PROVIDER_NOT_IMPLEMENTED = 501,
        PAYMENT_INVALID_PAYMENT_INTENTION = 502,
    }
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCodes { get; set; }
    }
}
