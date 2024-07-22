using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;



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


        [HttpGet("Car")]
        public Car GetCar()
        {
            Car car=new Car();

            return new Car {

                Maker = "Ford",
                Model = "Focus",
                Color = "Red",
                Price = 100,
                Year = "2025"
            };

        }

        [HttpPost("saveCar")]
        public IActionResult SaveCar([FromBody]Car Car)
        {
            //throw new Exception("Hata test");

          //  Retrieve data and return as JSON

            return new JsonResult(Car)
            {
                ContentType = "application/json",
                SerializerSettings = JsonSerializerOptions.Default,
                StatusCode = 200,
                Value = Car
            };

            //return $"Car successfully saved CarReferenceTransactionId: {new Random().Next(199,250)} ";
        }
    }


    public class Car
    {
        [JsonProperty(PropertyName = "Maker", Required = Required.AllowNull)]
        public string Maker { get; set; }

        [JsonProperty(PropertyName = "Model", Required = Required.Always)]
        public string Model { get; set; }
       
        [JsonProperty(PropertyName = "Color", Required = Required.Always)]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "Price", Required = Required.Always)]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "Year", Required = Required.Always)]
        public string Year { get; set; }



    }


}
