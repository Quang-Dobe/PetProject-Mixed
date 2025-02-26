using Microsoft.AspNetCore.Mvc;
using Practice.Asynchronous.Services;

namespace Practice.Asynchronous.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class OrchestorEndpointController : ControllerBase
	{
		private readonly IThirdPartyService _thirdPartyService;
		private readonly IOrchestorService _orchestorService;

        public OrchestorEndpointController(
			IThirdPartyService thirdPartyService,
			IOrchestorService orchestorService)
        {
			_thirdPartyService = thirdPartyService;
            _orchestorService = orchestorService;
        }

        [HttpGet]
		public async Task<bool> TestDoTask()
		{
			_orchestorService.DoTask();

			return true;
		}

		[HttpGet]
		public async Task<bool> TestDoTaskWithService()
		{
			_orchestorService.DoTask(_thirdPartyService);

			return true;
		}

		[HttpGet]
		public async Task<bool> TestDoLogic()
		{
			_orchestorService.DoLogic();

			return true;
		}

		[HttpGet]
		public async Task<bool> TestDoLogicWithService()
		{
			_orchestorService.DoLogic(_thirdPartyService);

			return true;
		}
	}
}
