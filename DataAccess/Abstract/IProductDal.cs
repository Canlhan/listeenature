using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
     public interface IProductDal:IEntityRepo<Product>
    {
        List<ProductDto> getProductDetail(int id);
        List<ProductDto> getProductS();
        List<ProductDto> getProductsCustomerId(int customerId);
    }
}
