using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBackend.API.Dto;
using CoreBackend.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CoreBackend.API.Controllers
{
    //对应dto-ProductModification
    //put 更新


    [Produces("application/json")]
    [Route("api/Put")]
    public class PutController : Controller
    {
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] ProductModification pro)
        {
            if (pro==null)
            {
                return BadRequest();
            }
            if (pro.Name=="产品")
            {
                ModelState.AddModelError("Name","产品名称不能为产品二字");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = ProductService.Current.Products.SingleOrDefault(x=>x.Id==id);
            if (model==null)
            {
                return NotFound();
            }
            model.Name = pro.Name;
            model.Price = pro.Price;
            model.Description = pro.Description;
            //return NoContent();
            return Ok(model);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductModifications> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var model = ProductService.Current.Products.SingleOrDefault(x => x.Id == id);

            if (model==null)
            {
                return NotFound();
            }
            var toPatch = new ProductModifications
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            patchDoc.ApplyTo(toPatch,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (toPatch.Name=="产品")
            {
                 ModelState.AddModelError("Name","产品名称不能只是产品二字");
            }
            //使用TryValidateModel(xxx)对model进行手动验证, 结果也会反应在ModelState里面
            TryValidateModel(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Name = toPatch.Name;
            model.Description = toPatch.Description;
            model.Price = toPatch.Price;
            return NoContent();
        }
    }
}