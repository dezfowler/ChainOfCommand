using System;
using System.Collections.Generic;
using ChainOfCommand;

namespace Example
{
	public class ProcessTerm : IProcessStep<KeyValuePair<string, string>>
	{
		public IOutput Execute(KeyValuePair<string, string> input)
		{
			var val = int.Parse(input.Value);

			switch(input.Key)
			{
				case "add":
					return new MyResult(val);
				case "subtract":
					return new MyResult(-val);
			}
			
			throw new ArgumentException("Unrecognised search op", "input");
		}
	}
}