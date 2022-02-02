using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Logic;
using WebApi.Controllers;
using WebApi.Models.Product;

namespace WebApi
{
    public class ProductController : BaseController
    {

        UnitOfWork unitOfWork;
        public ProductController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Products.GetList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(unitOfWork.Products.GetItem(id));
        }

        [HttpPost]
        public IActionResult Post(ProductCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Products.Create(model);
            return Ok(unitOfWork.Products.GetList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Products.Delete(id);
            return Ok(unitOfWork.Products.GetList());
        }

        [HttpPut]
        public IActionResult Put(ProductEditVM model)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
            }
            unitOfWork.Products.Edit(model);
            return Ok(unitOfWork.Products.GetList());
        }
    }
}
