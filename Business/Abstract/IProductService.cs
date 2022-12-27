using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
       IDataResult<List<ProductDto>> GetAll();
        Product GetById(int productId);
        IDataResult<Product> Add( Product product);
        IDataResult<List<ProductDto>> getByUserId(int userId);
        IDataResult<List<ProductDto>> productDtoById(int id);
        IDataResult<Product> updateProduct(Product product);
        IResult delete(Product product);



    }
}
