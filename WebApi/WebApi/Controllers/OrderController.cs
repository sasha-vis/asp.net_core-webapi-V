using Microsoft.AspNetCore.Mvc;
using WebApi.Logic;
using WebApi.Models;
using WebApi.Controllers;

namespace WebApi
{
    public class OrderController : BaseController
    {
        UnitOfWork unitOfWork;
        public OrderController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Orders.GetList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(unitOfWork.Orders.GetItem(id));
        }

        [HttpPost]
        public IActionResult Post(OrderCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Orders.Create(model);
            return Ok(unitOfWork.Orders.GetList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Orders.Delete(id);
            return Ok(unitOfWork.Orders.GetList());
        }

        [HttpPut]
        public IActionResult Put(OrderEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Orders.Edit(model);
            return Ok(unitOfWork.Orders.GetList());
        }
    }
}
