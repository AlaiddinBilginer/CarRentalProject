using Business.Abstract;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public IDataResult<Card> GetCard(string cardNumber, string cardHolderName, DateTime expiryDate, string CVV)
        {
            var card = _cardDal.Get(c => 
                    c.CardNumber == cardNumber &&
                    c.CardHolderName == cardHolderName &&
                    c.ExpiryDate == expiryDate &&
                    c.CVV == CVV);

            if(card != null)
            {
                return new SuccessDataResult<Card>(card, "Kart geçerli");
            }

            return new ErrorDataResult<Card>("Kart geçerli değil");
        }

        public IResult WithdrawMoney(Card card, decimal amount)
        {
            if(card.Balance >= amount)
            {
                card.Balance -= amount;
                _cardDal.Update(card);
                return new SuccessResult();
            }

            return new ErrorResult("Bakiye yetersiz");
        }
    }
}
