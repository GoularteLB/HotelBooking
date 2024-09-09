

public enum Status
{
    Sucess = 0,
    Fail = 1,
    Error = 2,
    Undefine = 3,
}


namespace Application.Payment.DTO
{
    public class PaymentStateDto
    {
        public Status Status { get; set; }
        public string PaymentId { get; set; }
        public DateTime CreditDate { get; set; }
        public string Message { get; set; }
    }
}
