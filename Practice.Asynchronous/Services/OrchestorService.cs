namespace Practice.Asynchronous.Services
{
	public class OrchestorService : IOrchestorService
	{
		private readonly ILogger<OrchestorService> _logger;

        public OrchestorService(ILogger<OrchestorService> logger)
        {
            _logger = logger;
        }

        public async Task DoTask()
		{
			await Task.Delay(5000);

			_logger.LogInformation("Complete orchestor task (tracking)");	
		}

		public async Task DoTask(IThirdPartyService service)
		{
			await service.DoTask();

			_logger.LogInformation("Complete orchestor 3rd task (tracking)");
		}

		public async void DoLogic()
		{
			await Task.Delay(5000);

			_logger.LogInformation("Complete orchestor task (no tracking)");
		}

		public async void DoLogic(IThirdPartyService service)
		{
			service.DoLogic();

			_logger.LogInformation("Complete orchestor 3rd task (no tracking)");
		}
	}
}
