using Microsoft.AspNetCore.Mvc;
using WebApi.Logic;
using WebApi.Models;
using WebApi.Controllers;

namespace WebApi
{
    public class CategoryController : BaseController
    {
        UnitOfWork unitOfWork;
        public CategoryController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Categories.GetList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(unitOfWork.Categories.GetItem(id));
        }

        [HttpPost]
        public IActionResult Post(CategoryCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Categories.Create(model);
            unitOfWork.Save();
            return Ok(unitOfWork.Categories.GetList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Categories.Delete(id);
            unitOfWork.Save();
            return Ok(unitOfWork.Categories.GetList());
        }


        [HttpPut]
        public IActionResult Put(CategoryEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Categories.Edit(model);
            unitOfWork.Save();
            return Ok(unitOfWork.Categories.GetList());
        }
    }
}
