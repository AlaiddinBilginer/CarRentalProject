using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<Card> GetCard(string cardNumber, string cardHolderName, DateTime expiryDate, string CVV);
        IResult WithdrawMoney(Card card, decimal amount);
    }
}
