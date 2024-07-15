using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependcyInjection
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly INumGenerator generator;


        public TestController(INumGenerator numGenerator)
        {
            generator=numGenerator;
        }

        [HttpGet]
        public String Get()
        {
            return generator.RandomValue.ToString();
        }
    }
}
