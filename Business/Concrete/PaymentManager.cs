using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly ICardService _cardService;
        private readonly ICustomerService _customerService;

        public PaymentManager(IPaymentDal paymentDal, ICardService cardService, ICustomerService customerService)
        {
            _paymentDal = paymentDal;
            _cardService = cardService;
            _customerService = customerService;

        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Pay(PaymentRequest paymentRequest)
        {
            var card = _cardService.GetCard(paymentRequest.CardNumber, paymentRequest.CardHolderName, paymentRequest.ExpiryDate, paymentRequest.CVV);

            var customer = _customerService.GetById(paymentRequest.CustomerId);

            if (card.Success)
            {
                var withdrawMoney = _cardService.WithdrawMoney(card.Data, paymentRequest.Amount);
                if(withdrawMoney.Success)
                {
                    Payment payment = new Payment();
                    payment.CardId = card.Data.Id;
                    payment.CustomerId = paymentRequest.CustomerId;
                    payment.Amount = paymentRequest.Amount;
                    if(customer.Data != null)
                    {
                        _paymentDal.Add(payment);
                        return new SuccessResult("Ödeme işlemi başarılı");
                    }
                    else
                    {
                        return new ErrorResult("Müşteri olmanız gerekiyor");
                    }

                } else
                {
                    return new ErrorResult(withdrawMoney.Message);
                }
            } else
            {
                return new ErrorResult("Kart bilgileriniz geçersiz");
            }

            
        }
    }
}
