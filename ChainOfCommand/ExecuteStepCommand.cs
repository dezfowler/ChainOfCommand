namespace ChainOfCommand
{
	public abstract class ExecuteStepCommand : IOutput
	{
		public abstract IOutput FindStepAndExecute(IHost host);
	}
}