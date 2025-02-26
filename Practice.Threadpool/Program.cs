// See https://aka.ms/new-console-template for more information
ThreadPool.QueueUserWorkItem(ThreadProc);
Console.WriteLine("Main thread does some work, then sleeps.");
Thread.Sleep(10000);

Console.WriteLine("Main thread exits.");

static void ThreadProc(Object stateInfo)
{
	// No state object was passed to QueueUserWorkItem, so stateInfo is null.
	Console.WriteLine("Hello from the thread pool.");
}