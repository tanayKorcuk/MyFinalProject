using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//attribute/annotation:javada
    public class ProductsController : ControllerBase
    {
        //products controller sen product servise bağımlısın>>loosely coupled
        //field actık injection qeyfi>>>hata alıyoruz gerçek bir referans istiyor?
        //IoC Container--Inverison of control
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {

            //loosely coupled
            //   IProductService productService = new ProductManager(new EfProductDal());//product service product managera product maneger ef productdal aihtiyac duyuyor
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);



        }//ende get methd
        [HttpGet("getbyid")]//delete ve güncelleme işlerinde post kullanılabilir
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getDetails")]
        public IActionResult GetProductsByCategoryId(int categoryId)//kullanılan methodda instancı nasıl veririz
        {
            //id = 3;
            var result = _productService.GetAll(p => p.CategoryId == categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }  //categorileri gez bizim berdiğimiz categorye eşit olanları returnle

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }

    }

}

