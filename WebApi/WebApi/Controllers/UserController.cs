using Microsoft.AspNetCore.Mvc;
using WebApi.Logic;
using WebApi.Models;
using WebApi.Controllers;
using WebApi.Models.User;

namespace WebApi
{
    public class UserController : BaseController
    {
        UnitOfWork unitOfWork;
        public UserController()
        {
            unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Users.GetList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(unitOfWork.Users.GetItem(id));
        }

        [HttpPost]
        public IActionResult Post(UserCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Users.Create(model);
            return Ok(unitOfWork.Users.GetList());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Users.Delete(id);
            return Ok(unitOfWork.Users.GetList());
        }

        [HttpPut]
        public IActionResult Put(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            unitOfWork.Users.Edit(model);
            return Ok(unitOfWork.Users.GetList());
        }
    }
}
