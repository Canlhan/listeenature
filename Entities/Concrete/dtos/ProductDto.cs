using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.dtos
{
    public class ProductDto
    {
       public string soundPath { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public DateTime createdat { get; set; }
    }
}
