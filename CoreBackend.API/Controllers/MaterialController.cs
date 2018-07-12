using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreBackend.API.Controllers
{
    //[Produces("application/json")]
    [Route("api/product")]
    public class MaterialController : Controller
    {
        [HttpGet("{productId}/materials")]
        public IActionResult GetMaterials(int productId)
        {
            var product = ProductService.Current.Products.SingleOrDefault(x => x.Id == productId);
            if (product ==null)
            {
                return NotFound();
            }
            return Ok(product.Materials);
        }

        [HttpGet("{productId}/materials/{id}")]
        public IActionResult GetMaterial(int productid, int id)
        {
            var product = ProductService.Current.Products.SingleOrDefault(x => x.Id == productid);
            if (product ==null)
            {
                return NotFound();
            }
            var material = product.Materials.SingleOrDefault(x => x.Id == id);
            if (material==null)
            {
                return NotFound();
            }
            return Ok(material);
        }

       
    }


}