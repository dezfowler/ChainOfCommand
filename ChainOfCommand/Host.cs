using System;
using System.Collections.Generic;

namespace ChainOfCommand
{
	public class Host : IHost
	{
		private readonly IDictionary<Type, object> _steps;

		public Host(IDictionary<Type, object> steps)
		{
			_steps = steps;
		}

		public IResult Execute(ExecuteStepCommand executeStepCommand)
		{
			var output = executeStepCommand.FindStepAndExecute(this);

			var result = output as IResult;

			return result ?? Execute((ExecuteStepCommand)output);
		}

		public object Find(Type commandType)
		{
			return _steps[commandType];
		}
	}
}