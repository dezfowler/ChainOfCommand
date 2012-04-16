using System;
using System.Collections.Generic;
using ChainOfCommand;

namespace Example
{
	public class SearchEngine
	{
		private readonly IHost _host;

		public SearchEngine() : this(null) {}

		internal SearchEngine(IHost host)
		{
			_host = host ?? BuildDefaultHost();
		}

		private static IHost BuildDefaultHost()
		{
			var steps = new Dictionary<Type, object>
       	{
       		{typeof(ParseSearchTermsStep), new ParseSearchTermsStep()},
       		{typeof(ProcessTerm), new ProcessTerm()},
				{typeof(CompileResultsStep), new CompileResultsStep()},
       	};

			return new Host(steps);
		}

		public SearchResult ExecuteSearch(Dictionary<string, string> searchTerms)
		{
			if (searchTerms == null) throw new ArgumentNullException("searchTerms");

			var start = new ExecuteStepCommand<ParseSearchTermsStep, Dictionary<string, string>>(searchTerms);
			var result = _host.Execute(start);

			var errorResult = result as ErrorResult;
			if (errorResult != null)
			{
				throw new Exception(errorResult.Message);
			}

			return (SearchResult)result;
		}
	}
}