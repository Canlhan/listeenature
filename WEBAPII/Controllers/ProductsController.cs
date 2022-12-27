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
        public IActionResult getall()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

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

        [HttpPut("update")]
        public IActionResult updateproduct(Product product)
        {

            var result = _productService.updateProduct(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("olmadı");
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
           var result= _productService.Add(product);

            return Ok(result);
        }

        [HttpGet("getcustomerid/{userId}")]
        public IActionResult getByCustomerId(int userId)
        {
            var result = _productService.getByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpDelete("delete")]
        public IActionResult deleteProduct(Product product)
        {
            var result = _productService.delete(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
