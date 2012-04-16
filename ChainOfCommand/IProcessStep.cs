namespace ChainOfCommand
{
	public interface IProcessStep<TInput>
	{
		IOutput Execute(TInput input);
	}
}