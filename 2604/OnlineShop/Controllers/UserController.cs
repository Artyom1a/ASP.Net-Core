using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.Repository;
using OnlineShop.Repositories;
using OnlineShop.Services;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserServices services;
        private readonly UserRepository m_Repos;
        public UserController(UserServices userServices, UserRepository userRepository)
        {
            services = userServices;
            m_Repos = userRepository;
        }

        //GET “/user”
        [AllowAnonymous]
        [ResponseCache(Duration = 60)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(services.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(services.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //        POST “/user” – с клиента приходит объект вида { "name": "Hanna", "surname":
        //"Pleshko", "email": "hannapleshko@gmail.com", "pwd": "12345678" }. Добавить в БД
        //объект в том случае, если совпадений с почтой в БД нет.Вернуть клиенту коду
        //нового объекта, статус
        [HttpPost("getbyid/{id}")]
        public IActionResult Create(User user)
        {
            try
            {
                services.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                return Ok(services.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                return Ok(services.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
