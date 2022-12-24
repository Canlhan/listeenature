using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface ICartService
    {

        List<Cart> GetAll();
       Cart GetById(int cartId);
        void Add(Cart cart);
        Cart GetByCustomerId(int userId);
    }
}
