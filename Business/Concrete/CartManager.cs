using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class CartManager : ICartService
    {

        ICartDal _cartDal;

        public  CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void Add(Cart cart)
        {
            _cartDal.Add(cart);
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }

        public Cart GetById(int cartId)
        {
            return _cartDal.Get((cart) => cart.Id == cartId);
        }
        public Cart GetByCustomerId(int userId)
        {

            return _cartDal.Get((cart) => cart.UserId == userId);
        }
    }
}
