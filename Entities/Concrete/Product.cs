using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int id { get; set; }
       
        
        public int userId { get; set; }
        public string? name { get; set; }
        public int price { get; set; }

        public string description { get; set; }
       

      
    }
}
