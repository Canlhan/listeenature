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
        List<Product> GetAll();
        Product GetById(int productId);
        void Add( Product product);
        List<Product> getByUserId(int userId);
        IDataResult<List<ProductDto>> productDtoById(int id);

       
    }
}
