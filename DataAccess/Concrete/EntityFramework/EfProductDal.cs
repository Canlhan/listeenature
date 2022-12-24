using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, dbContext>, IProductDal
    {
        public List<ProductDto> getProductDetail(int id)
        {
            using (dbContext context = new dbContext())
            {
                var result = from p in context.Product
                             join r in context.Ringtone
                             on p.id equals r.productId
                             where p.id == id
                             select new ProductDto
                             {
                                 createdat = r.createdat,
                                 description = p.description,
                                 name = p.name,
                                 price = p.price,
                                 soundPath = r.soundPath
                             };
                return result.ToList();
            }
        }
    }
}
