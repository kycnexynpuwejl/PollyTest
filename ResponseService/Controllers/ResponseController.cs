using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : ControllerBase
    {
        //GET /api/response/{id}

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetResponse(int id)
        {
            Random rnd = new Random();
            var rndInteger = rnd.Next(1,100);
            if(rndInteger >= id)
            {
                Console.WriteLine("--> Failure - Generate HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Success - Generate HTTP 200");
            return Ok();
        }   
    }
}