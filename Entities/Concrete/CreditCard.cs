using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public  class CreditCard:IEntity
    {
        public int id { get; set; }
        public string cardnumber { get; set; }
        public string cardname { get; set; }
        public string date { get; set; }
        public string cvc { get; set; }
        public int userId { get; set; }

    }
}
