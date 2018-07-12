using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreBackend.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Delete")]
    public class DeleteController : Controller
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = ProductService.Current.Products.SingleOrDefault(x => x.Id == id);
            if (model==null)
            {
                return NotFound();
            }
            ProductService.Current.Products.Remove(model);
            
            return NoContent();
        }
    }
}