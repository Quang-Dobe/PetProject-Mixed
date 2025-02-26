namespace Practice.Asynchronous.Services
{
	public interface IOrchestorService
	{
		Task DoTask();

		Task DoTask(IThirdPartyService service);

		void DoLogic();

		void DoLogic(IThirdPartyService service);
	}
}
