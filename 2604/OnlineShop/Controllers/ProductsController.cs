//using Microsoft.AspNetCore.Mvc;
//using OnlineShop.Services;

//namespace OnlineShop.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ProductsController : ControllerBase
//    {


//        private readonly ProductsService p_services;
//        public ProductsController(ProductsService service)
//        {
//            p_services = service;
//        }
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            try
//            {
//                return Ok(p_services.GetAll());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpGet("getbyid/{id}")]
//        public IActionResult GetById(int id)
//        {
//            try
//            {
//                return Ok(p_services.GetById(id));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPost("create/{id}")]
      
//        public IActionResult Create()
//        {
//            try
//            {
//                return Ok(p_services.Create());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPut("update/{id}")]
//        public IActionResult UpdateUser()
//        {
//            try
//            {
//                return Ok(p_services.Update());
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpDelete("delete/{id}")]
//        public IActionResult DeleteUser(int id)
//        {
//            try
//            {
//                return Ok(p_services.Delete(id));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }
//    }
//}
