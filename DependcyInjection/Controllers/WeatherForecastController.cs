using Microsoft.AspNetCore.Mvc;

namespace DependcyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly INumGenerator numGenerator1;
        private readonly INumGenerator2 numGenerator2;
  

        public WeatherForecastController(INumGenerator2 _number2, INumGenerator _number)
        {
            numGenerator1 = _number;
            numGenerator2 = _number2;           
  
        }

        [HttpGet()]
        public String Get()
        {
            int randomNumber1 = numGenerator1.RandomValue;
            int randomNumber2 = numGenerator2.RandomValue;

            return $"NumGenerator1.RandomValue:{randomNumber1} NumGenerator2.RandomValue:{randomNumber2}";
        }
    }
}
