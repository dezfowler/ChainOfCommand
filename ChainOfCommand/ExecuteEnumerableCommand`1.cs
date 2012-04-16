using System.Collections.Generic;

namespace ChainOfCommand
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TContinuation">Continuation command</typeparam>
	public class ExecuteEnumerableCommand<TContinuation> : ExecuteEnumerableCommand
		where TContinuation : IProcessStep<AggregateResult>
	{
		public ExecuteEnumerableCommand(IEnumerable<ExecuteStepCommand> commands)
			: base(commands)
		{
		}

		protected override IOutput GetOutput(AggregateResult result)
		{
			return new ExecuteStepCommand<TContinuation, AggregateResult>(result);
		}
	}
}