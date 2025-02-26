using Microsoft.AspNetCore.Mvc;

namespace Practice.Docker.Controllers
{
	[Route("api/test")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]
		public async Task<bool> GetAsync()
		{
			return true;
		}

		[HttpPost]
		public async Task<object> PostAsync()
		{
			return true;
		}
	}
}
