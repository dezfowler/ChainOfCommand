using System;
using System.Collections.Generic;
using System.Text;
using ChainOfCommand;

namespace Example
{
	public class ParseSearchTermsStep : IProcessStep<Dictionary<string, string>>
	{
		public IOutput Execute(Dictionary<string, string> input)
		{
			if (input == null || input.Count == 0)
			{
				return ErrorResult.NoSearchTerms;
			}

			return ProcessTerms(input).AsOutput<CompileResultsStep>();
		}

		private IEnumerable<ExecuteStepCommand> ProcessTerms(Dictionary<string, string> input)
		{
			foreach (var item in input)
			{
				yield return new ExecuteStepCommand<ProcessTerm, KeyValuePair<string, string>>(item);
			}
		}
	}
}
