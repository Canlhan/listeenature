using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ringtone:IEntity
    {
        public int id { get; set; }
        public string soundPath { get; set; }

        public DateTime createdat { get; set; }

         public int productId { get; set; }

    }
}
