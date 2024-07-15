using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            //throw new Exception("Hata test");

            return "Ok";
        }
    }

    public class Number {

        public int theBiggestNumber { get; set; }
    }
}
