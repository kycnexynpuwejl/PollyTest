using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        //GET api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            //var client = new HttpClient();

            var client = _clientFactory.CreateClient("Test");
            
            var response = await client.GetAsync("http://localhost:5100/api/response/25");
            
            // var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("http://localhost:5100/api/response/25"));

            // var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("http://localhost:5100/api/response/25"));

            // var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("http://localhost:5100/api/response/25"));

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned SUCCESS");
                return Ok();
            }
                Console.WriteLine("--> ResponseService returned FAIURE");
                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}