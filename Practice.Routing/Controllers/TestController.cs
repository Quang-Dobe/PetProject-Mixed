using Microsoft.AspNetCore.Mvc;

namespace Practice.Routing.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<bool> GetAsync()
        {
            Console.WriteLine("- ASPNETCORE_ENVIRONMENT: ", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            Console.WriteLine("- First_Variable: ", Environment.GetEnvironmentVariable("First"));
            Console.WriteLine("- Second_Variable: ", Environment.GetEnvironmentVariable("Second"));

            return true;
        }

        [HttpPost]
        [Route("post")]
        public async Task<bool> PostAsync()
        {
            Console.WriteLine("- ASPNETCORE_ENVIRONMENT: ", configuration["ASPNETCORE_ENVIRONMENT"]);
            Console.WriteLine("- First_Variable: ", configuration["First"]);
            Console.WriteLine("- Second_Variable: ", configuration["Second"]);

            return false;
        }
    }
}
