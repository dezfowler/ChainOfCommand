using ChainOfCommand;

namespace Example
{
	public class MyResult : IResult
	{
		public MyResult(object result)
		{
			Value = result;
		}

		public object Value { get; private set; }
	}
}