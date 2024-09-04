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
        ROOM_GUEST_NOT_FOUND = 105
    }
    public class Response
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public ErrorCodes ErrorCodes { get; set; }
    }
}
