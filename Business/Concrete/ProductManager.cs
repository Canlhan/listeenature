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
        public IDataResult<Product> Add( Product product)
        {

            _productDal.Add(product);

            var productget = _productDal.Get((produ) => produ.name == product.name);
            if (product!=null)
            {

                
                return new SuccessDataResult<Product>(productget, "oldu");

            }
            return new ErrorDataResult<Product>();
           // var addedproduct = CreatedFile(product).Data;
            
        }

        public IDataResult<List<ProductDto>> GetAll()
        {

            return new SuccessDataResult<List<ProductDto>>(_productDal.getProductS(), "oldu");
        }

        

        public Product GetById(int productId)
        {
            return _productDal.Get((product) => product.id == productId);
        }

        public IDataResult<Product> updateProduct(Product product)
        {
             _productDal.Update(product);

            return new SuccessDataResult<Product>("oldu ");
            
        }

        public IDataResult<List<ProductDto>> getByUserId(int userId)
        {
            var result = _productDal.getProductsCustomerId(userId);
            if (result!=null)
            {
                return new SuccessDataResult<List<ProductDto>>(result);
            }

            return new ErrorDataResult<List<ProductDto>>();
        }

        public IDataResult<List<ProductDto>> productDtoById(int id)
        {

            return new SuccessDataResult<List<ProductDto>>(_productDal.getProductDetail(id),"oldu");
        }

        private IDataResult<Product> CreatedFile(Product product)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
            var uniqueFilename = Guid.NewGuid().ToString("N")
                + "sound-" + product.id + "-" + DateTime.Now.ToShortDateString();

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

        public IResult delete(Product product)
        {

            _productDal.Delete(product);
            return new SuccessResult();
        }
    }
}
