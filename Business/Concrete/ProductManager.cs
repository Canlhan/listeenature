using Business.Abstract;
using Core.Utilities.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    class ProductManager : IProductService
    {
        IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void  Add( Product product)
        {

           

           // var addedproduct = CreatedFile(product).Data;
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
          return _productDal.GetAll();
        }

        

        public Product GetById(int productId)
        {
            return _productDal.Get((product) => product.id == productId);
        }

        public List<Product> getByUserId(int userId)
        {
            return _productDal.GetAll((product) => product.userId == userId);
        }

        public IDataResult<List<ProductDto>> productDtoById(int id)
        {

            return new SuccessDataResult<List<ProductDto>>(_productDal.getProductDetail(id),"oldu");
        }

        private IDataResult<Product> CreatedFile(Product product)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
            var uniqueFilename = Guid.NewGuid().ToString("N")
                + "sound-" + product.userId + "-" + DateTime.Now.ToShortDateString();

           // string source = Path.Combine(product.ringtone);

            string result = $@"{path}\{uniqueFilename}";

            try
            {

              //  File.Move(source, path + @"\" + uniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Product>(exception.Message);
            }

            // return new SuccessDataResult<Product>(new Product {  userId = product.userId, ringtone = result, createdat = DateTime.Now }, "resim eklendi");
            return new SuccessDataResult<Product>("HAY");
        }
    }
}
