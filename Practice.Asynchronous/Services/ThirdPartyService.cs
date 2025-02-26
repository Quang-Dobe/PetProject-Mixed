namespace Practice.Asynchronous.Services
{
	public class ThirdPartyService : IThirdPartyService
	{
        private readonly ILogger<ThirdPartyService> _logger;

        public ThirdPartyService(ILogger<ThirdPartyService> logger)
        {
            _logger = logger;
        }

        public async Task DoTask()
        {
            await Task.Delay(5000);

            _logger.LogInformation("Complete 3rd task (tracking)");
        }

        public async void DoLogic()
        {
            await Task.Delay(5000);

            _logger.LogInformation("Complete 3rd task (Not tracking)");
        }
    }
}
