using Practice.DesignPattern.RailwayOrientedProgramming.Common;

var request = Guid.NewGuid();

var result = Start(request)
	.Bind(_ => Validation(request))
	.TryCatch(_ => Execution(_), Error.NoLineItems)
	.Tap(_ => ExecutionNext(request))
	.Match(
		data => Guid.NewGuid(),
		error => Guid.Empty);


Result<string> Start(Guid request)
{
	return Result<string>.Success("");
}

Result<bool> Validation(Guid request)
{
	return Result<bool>.Success(true);
}

Result<int> Execution(bool validation)
{
	return Result<int>.Success(1);
}

void ExecutionNext(Guid request)
{

}

