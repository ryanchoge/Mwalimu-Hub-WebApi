using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mwalimu_Hub_WebApi.Controllers
{
   
    //[ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
