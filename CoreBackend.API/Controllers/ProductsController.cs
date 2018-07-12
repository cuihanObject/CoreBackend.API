using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.API.Dto;
using Microsoft.AspNetCore.Mvc;
using CoreBackend.API.Services;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreBackend.API.Controllers
{

    [Route("api/[controller]")]
    public class ProductsController : Controller
    {


        //private ILogger<ProductsController> _logger;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMailService _mailService;
        public ProductsController(ILogger<ProductsController> logger,
                                   IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        // GET: api/<controller>

        //public JsonResult GetProducts()
        //{
        //    return new JsonResult(
        //        new List<Product> {
        //            new Product{
        //                Id=1,
        //                Name="牛奶",
        //                Price=2.5f
        //            },
        //            new Product {
        //                Id =2,
        //                Name="面包",
        //                Price=1.5f
        //            }
        //    });
        //}



        //[HttpGet]
        //public IActionResult  GetList()
        //{
        //    //return new JsonResult(ProductService.Current.Products);
        //    return Ok(ProductService.Current.Products);

        //}

        //[Route("{id}")]
        //public IActionResult GetList(int id)
        //{

        //    var list = ProductService.Current.Products.Where(x => x.Id == id);
        //    if (list == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(list);
        //    }
        //}


        [Route("{id}",Name = "GetProducts")]
        public IActionResult GetProducts(int id)
        {
            try
            {
                throw new Exception("跳到异常");
                var list = ProductService.Current.Products.SingleOrDefault(x => x.Id == id);
                if (list == null)
                {
                    _logger.LogInformation($"Id为{id}的产品没有被找到...");
                    return NotFound();
                }

                return Ok(list);

            }
            catch(Exception ex)
            {
                _mailService.SendEmail("Products ERROR", $"获取Id为{id}的产品时，出现了异常！");
                //_logger.LogCritical($"查找Id为{id}的产品时除了错误！",ex);
                return StatusCode(500,"处理请求时，发生了错误！");
            }
        }

        /// <summary>
        /// post==添加
        /// </summary>
        /// <param name="product">产品实体</param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Post([FromBody] ProductCreation product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            //对验证的逻辑判断
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (product.Name=="啦啦")
            {
                ModelState.AddModelError("Name","名称不能为啦啦");
                return BadRequest(ModelState);
            }
            var maxId = ProductService.Current.Products.Max(x => x.Id);
            var newProduct = new Product
            {
                Id = ++maxId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
            ProductService.Current.Products.Add(newProduct);

            return CreatedAtRoute("GetProducts", new { id = newProduct.Id }, newProduct);
        }



    }
}
