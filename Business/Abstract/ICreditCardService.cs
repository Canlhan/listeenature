using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {

        IDataResult<CreditCard> getCard(string cardnumber);

        IDataResult<List<CreditCard>> getCards();

        IDataResult<CreditCard> addCard(CreditCard creditCard);

        IDataResult<CreditCard> getCardsByUserId(int id);

    }
}
