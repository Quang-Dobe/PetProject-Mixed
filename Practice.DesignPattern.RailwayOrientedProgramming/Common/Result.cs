namespace Practice.DesignPattern.RailwayOrientedProgramming.Common
{
	public class Result<T>
	{
		private Result(T value)
		{
			Value = value;
			IsSuccess = true;
		}

		private Result(Error error)
		{
			Error = error;
			IsSuccess = false;
		}

		public T Value { get; }

		public Error Error { get; }

		public bool IsSuccess { get; private set; }

		public static Result<T> Success(T value) => new(value);

		public static Result<T> Failure(Error error) => new(error);
	}

	public record Error(ErrorType type, string message)
	{
		public static Error NoLineItems = new(ErrorType.Validation, "Line items are empty");

		public static Error NotEnoughStock = new(ErrorType.Validation, "Not enough stock for order");

		public static Error PaymentFailed = new(ErrorType.Failure, "Failed to process payment");
	}

	public enum ErrorType
	{
		Failure = 0,
		Validation = 1
	}
}
