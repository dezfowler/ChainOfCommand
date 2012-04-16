using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfCommand
{
	public class ExecuteEnumerableCommand : ExecuteStepCommand
	{
		private readonly IEnumerable<ExecuteStepCommand> _commands;

		public ExecuteEnumerableCommand(IEnumerable<ExecuteStepCommand> commands)
		{
			if (commands == null) throw new ArgumentNullException("commands");

			_commands = commands;
		}

		public override IOutput FindStepAndExecute(IHost host)
		{
			var results = _commands.Aggregate(
				new AggregateResult(), 
				(agg, command) =>
         	{
         		agg.AddResult(host.Execute(command));
         		return agg;
         	}, 
				agg => agg);

			return GetOutput(results);
		}

		protected virtual IOutput GetOutput(AggregateResult result)
		{
			return result;
		}
	}
}