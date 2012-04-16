using System.Collections.Generic;

namespace ChainOfCommand
{
	public class AggregateResult : IResult
	{
		private readonly List<IResult> _results = new List<IResult>();

		public void AddResult(IResult result)
		{
			_results.Add(result);
		}

		public IEnumerable<IResult> Results
		{
			get
			{
				return _results.AsReadOnly();
			}
		}
	}
}