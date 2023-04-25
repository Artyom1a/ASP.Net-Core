using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : Controller
    {
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                LanguageServices languageServices = new LanguageServices();
                return Ok(await languageServices.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[HttpGet("getbyid/{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    try
        //    {
        //        LanguageServices languageServices = new LanguageServices();
        //        return Ok(await languageServices.GetById(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        [HttpPost("create")]
        public async Task<IActionResult> Create(Language data )
        {
            try
            {
                LanguageServices languageServices = new LanguageServices();
                await languageServices.Create(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
