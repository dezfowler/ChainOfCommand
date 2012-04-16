using System.Collections.Generic;

namespace ChainOfCommand
{
	public static class OutputExtensions
	{
		/// <summary>
		/// Wrap <paramref name="commands"/> up in <see cref="ExecuteEnumerableCommand"/> which 
		/// aggregates results from each command and returns as AggregateResult.
		/// </summary>
		/// <param name="commands">Commands to be executed</param>
		/// <returns></returns>
		public static ExecuteEnumerableCommand AsOutput(this IEnumerable<ExecuteStepCommand> commands)
		{
			return new ExecuteEnumerableCommand(commands);
		}
		
		/// <summary>
		/// Wrap <paramref name="commands"/> up in <see cref="ExecuteEnumerableCommand"/> which 
		/// aggregates results from each command and then passes this to <typeparamref name="TContinuation"/>.
		/// </summary>
		/// <typeparam name="TContinuation">Process on AggregateResult to continue with</typeparam>
		/// <param name="commands">Commands to be executed</param>
		/// <returns></returns>
		public static ExecuteEnumerableCommand AsOutput<TContinuation>(this IEnumerable<ExecuteStepCommand> commands)
			where TContinuation : IProcessStep<AggregateResult>
		{
			return new ExecuteEnumerableCommand<TContinuation>(commands);
		}
	}
}