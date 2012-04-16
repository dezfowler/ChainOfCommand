using ChainOfCommand;

namespace Example
{
	public class ErrorResult : IResult
	{
		public static readonly ErrorResult NoSearchTerms = new ErrorResult("No search terms");

		public ErrorResult(string message)
		{
			Message = message;
		}

		public string Message { get; private set; }
	}
}