using System.Linq;
using ChainOfCommand;

namespace Example
{
	public class CompileResultsStep : IProcessStep<AggregateResult>
	{
		public IOutput Execute(AggregateResult input)
		{
			var sum = input.Results
				.OfType<MyResult>()
				.Select(r => r.Value)
				.OfType<int>()
				.Sum();

			return new SearchResult(sum);
		}
	}
}