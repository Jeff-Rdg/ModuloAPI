using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModuloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("getdatehour")]
        public IActionResult GetDateHour()
        {
            var obj = new
            {
                date = DateTime.Now.ToLongDateString(),
                hour = DateTime.Now.ToLongTimeString(),
            };

            return Ok(obj);
        }

        [HttpGet("getmessage/{name}")]
        public IActionResult GetMessage(string name)
        {
            var message = $"Olá {name}, seja bem vindo!";
            return Ok(new {message});
        }
    }
}
