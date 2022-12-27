using Business.Abstract;
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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;

        }
        public IDataResult<CreditCard> addCard(CreditCard creditCard)
        {
            

            var result = _creditCardDal.Get((card)=> card.cardnumber==creditCard.cardnumber && card.date==creditCard.date &&
            
            card.cvc==creditCard.cvc && card.cardname==creditCard.cardname && card.userId==creditCard.userId
            );
            
            if (result==null)
            {
                return new ErrorDataResult<CreditCard>("kredi kartı yok");
            }
            

            
            
            return new SuccessDataResult<CreditCard>("kart bilgileri doğru");
            

           

        }
            
            
            
            


           
            

       

        public IDataResult<CreditCard> getCard(string cardnumber)
        {
            var result = _creditCardDal.Get((card) => card.cardnumber == cardnumber);
            if (result!=null)
            {

                return new SuccessDataResult<CreditCard>(result);
            }
            return new ErrorDataResult<CreditCard>();
        }

        public IDataResult<List<CreditCard>> getCards()
        {
            var result = _creditCardDal.GetAll();
            if (result != null)
            {

                return new SuccessDataResult<List<CreditCard>>(result);
            }
            return new ErrorDataResult<List<CreditCard>>();
        }

        public IDataResult<CreditCard> getCardsByUserId(int id)
        {

            var result = _creditCardDal.Get((card) => card.userId == id);
            if (result!=null)
            {

                return new SuccessDataResult<CreditCard>(result);
            }
            return new ErrorDataResult<CreditCard>("bu kullanıcının kartı yok");
        }
    }
}
