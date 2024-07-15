using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public String Get() {

            int a = 10;
            int b = 0;

            int c = a / b;

            return "OkTest";
        }  
    }
}
