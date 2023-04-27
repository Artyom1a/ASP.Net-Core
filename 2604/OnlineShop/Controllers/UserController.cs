using Microsoft.AspNetCore.Mvc;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    [ApiController]
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
    }
}
