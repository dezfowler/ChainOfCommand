namespace ChainOfCommand
{
	public class ExecuteStepCommand<TProcessStep, TInput> : ExecuteStepCommand
		where TProcessStep : IProcessStep<TInput>
	{
		public ExecuteStepCommand(TInput input)
		{
			Value = input;
		}

		public TInput Value { get; private set; }

		public override IOutput FindStepAndExecute(IHost host)
		{
			var step = (IProcessStep<TInput>)host.Find(typeof(TProcessStep));
			return step.Execute(Value);
		}
	}
}