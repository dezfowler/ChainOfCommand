using System;

namespace ChainOfCommand
{
	public interface IHost
	{
		IResult Execute(ExecuteStepCommand executeStepCommand);

		object Find(Type commandType);
	}
}