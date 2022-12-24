using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;

        IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IProductService productService,IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public List<Product> getall()
        {

            return _productService.GetAll();

        }

        [HttpGet("gebyid/{id}")]
        public Product getbyid(int id)
        {

            return _productService.GetById(id);
        }


        [HttpGet("getdetail/{id}")]
        public IActionResult getDetail(int id)
        {
            var result = _productService.productDtoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult add(Product product)
        {

            /*
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var newguid = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newguid))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            _productService.Add(new Product
            {
                name = product.name,
                price = product.price,
                ringtone = newguid,
                description = product.description
            });

            System.Diagnostics.Debug.WriteLine("SomeText");
            */
            _productService.Add( product);
            return Ok("oldu");
        }

        [HttpGet("getcustomerid/{userId}")]
        public List<Product> getByCustomerId(int userId)
        {

            return _productService.getByUserId(userId);

        }
    }
}
