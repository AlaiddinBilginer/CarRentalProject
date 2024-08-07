using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(PaymentRequest paymentRequest);
    }
}
