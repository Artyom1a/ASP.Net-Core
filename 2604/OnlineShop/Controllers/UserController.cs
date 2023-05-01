using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using OnlineShop.Models.Repository;
using OnlineShop.Repositories;
using OnlineShop.Services;
using System.Data.Common;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserRepository m_Service;
        public UserController(UserRepository userRepository)
        {
            m_Service = userRepository;
        }

        //GET “/user”
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(m_Service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles ="Admin")]
        [HttpGet("getbyid/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(m_Service.GetById(id));
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
                UserServices userServices = new UserServices(m_Service);
                userServices.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
