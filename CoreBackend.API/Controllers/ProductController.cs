using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.API.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public JsonResult GetProducts()
        {
            return new JsonResult(
                new List<Product> {
                    new Product{
                        Id=1,
                        Name="牛奶",
                        Price=2.5f
                    },
                    new Product {
                        Id =2,
                        Name="面包",
                        Price=1.5f
                    } 
            });
        }
    }
}