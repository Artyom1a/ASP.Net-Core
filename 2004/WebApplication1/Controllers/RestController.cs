using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestController : ControllerBase
    {
        //1. Поставить сервер
        //2. Добавить 2 обработчика маршрута: get, post

        //https://localhost:7084/api/rest/1

        //[HttpGet("{id}")]
        //public  ActionResult Get(int id)
        //{
        //    return id%3==0 ? BadRequest() : Ok("Good");
        //}


  
        //8. Для put с url “/:id” запроса добавить обновление массива по id и 
        //     возвращать обновленный массив, статус ответа



    }
}
