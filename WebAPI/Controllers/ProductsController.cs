using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute bir class ile ilgi bilgi verme, imzalama yontemidir
    public class ProductsController : ControllerBase
    {//Loosely coupled 
        //Ioc --Inversion of control
        IProductService _productService;

        public ProductsController(IProductService productService) //IProductService injectioni yapti
        {
            _productService = productService;
        }

        [HttpGet("getall")]
      public IActionResult GetAll() //Get requestlerde 200 statu kodu doner
            //Bu apiyi gelistirenler ne zaman nasil kullanicagina dair dokumantosyon verilir
        {
            //Dependency chain
            //IProductService productService = new PruductManager(new EfPoductDal());
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); //StatusCode 200 
            }
            return BadRequest(result); //statusCode 400
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product) //Kontrolirin bildigi yer burasi, istedigimiz nesneyi buraya yazariz. Angular, react, nesne vs.
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
